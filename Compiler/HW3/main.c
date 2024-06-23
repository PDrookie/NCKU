#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <inttypes.h>

#define WJCL_LINKED_LIST_IMPLEMENTATION
#include "main.h"
#define WJCL_HASH_MAP_IMPLEMENTATION
//#include "value_operation.h"

#define debug printf("%s:%d: ############### debug\n", __FILE__, __LINE__)

#define iload(var) code("\tiload %" PRId64 " ; %s", (var)->symbol->addr, (var)->symbol->name)
#define lload(var) code("\tlload %" PRId64 " ; %s", (var)->symbol->addr, (var)->symbol->name)
#define fload(var) code("\tfload %" PRId64 " ; %s", (var)->symbol->addr, (var)->symbol->name)
#define dload(var) code("\tdload %" PRId64 " ; %s", (var)->symbol->addr, (var)->symbol->name)
#define aload(var) code("\taload %" PRId64 " ; %s", (var)->symbol->addr, (var)->symbol->name)

#define istore(var) code("\tistore %" PRId64 " ; %s", (var)->symbol->addr, (var)->symbol->name)
#define lstore(var) code("\tlstore %" PRId64 " ; %s", (var)->symbol->addr, (var)->symbol->name)
#define fstore(var) code("\tfstore %" PRId64 " ; %s", (var)->symbol->addr, (var)->symbol->name)
#define dstore(var) code("\tdstore %" PRId64 " ; %s", (var)->symbol->addr, (var)->symbol->name)
#define astore(var) code("\tastore %" PRId64 " ; %s", (var)->symbol->addr, (var)->symbol->name)

#define ldz(val) code("ldc %d", getBool(val))
#define ldb(val) code("ldc %d", getByte(val))
#define ldc(val) code("ldc %d", getChar(val))
#define lds(val) code("ldc %d", getShort(val))
#define ldi(val) code("ldc %d", getInt(val))
#define ldl(val) code("ldc_w %" PRId64, getLong(val))
#define ldf(val) code("ldc %.6f", getFloat(val))
#define ldd(val) code("ldc_w %lf", getDouble(val))
#define ldt(val) code("ldc \"%s\"", getString(val))

const char* objectTypeName[] = {
    [OBJECT_TYPE_UNDEFINED] = "undefined",
    [OBJECT_TYPE_VOID] = "void",
    [OBJECT_TYPE_BOOL] = "bool",
    [OBJECT_TYPE_BYTE] = "byte",
    [OBJECT_TYPE_CHAR] = "char",
    [OBJECT_TYPE_SHORT] = "short",
    [OBJECT_TYPE_INT] = "int",
    [OBJECT_TYPE_LONG] = "long",
    [OBJECT_TYPE_FLOAT] = "float",
    [OBJECT_TYPE_DOUBLE] = "double",
    [OBJECT_TYPE_STR] = "string",
};
const char* objectJavaTypeName[] = {
    [OBJECT_TYPE_UNDEFINED] = "V",
    [OBJECT_TYPE_VOID] = "V",
    [OBJECT_TYPE_BOOL] = "Z",
    [OBJECT_TYPE_BYTE] = "B",
    [OBJECT_TYPE_CHAR] = "C",
    [OBJECT_TYPE_SHORT] = "S",
    [OBJECT_TYPE_INT] = "I",
    [OBJECT_TYPE_LONG] = "J",
    [OBJECT_TYPE_FLOAT] = "F",
    [OBJECT_TYPE_DOUBLE] = "D",
    [OBJECT_TYPE_STR] = "Ljava/lang/String;",
};

char* yyInputFileName;
bool compileError;

int scopeLevel = -1;
int idx = 0;
int variableAddress = 0;
int last_addr = 0;
Object *Head = NULL, *Tail = NULL, *FuncDef = NULL;
bool inMain = false, toReturn = false, NoReturn = true;
int compare_cnt = 0, equal_cnt = 0;
int if_cnt = 0, else_cnt = 0;
int while_cnt = 0, for_cnt = 0, cur_loop = 0;

void pushScope(){    
    idx = 0;
    printf("> Create symbol table (scope level %d)\n", ++ scopeLevel);
}
void dumpScope(){
    printf("\n> Dump symbol table (scope level: %d)\n", scopeLevel);
    printf("%-10s%-20s%-10s%-10s%-10s%-10s\n",
            "Index", "Name", "Type", "Addr", "Lineno", "Func_sig");
    
    Object *table = Tail;
    if(!table) return;
    while (table->symbol->level == scopeLevel && table->symbol->index) table = table->prev;
    if (table->symbol->level != scopeLevel) {
        scopeLevel --;
        return;
    }

    Tail = table->prev;

    if(Tail){
        Tail->next = NULL;
        idx = Tail->symbol->index + 1;
    }

    while(table->next) {
        printf("%-10d%-20s%-10s%-10ld%-10d%-10s\n",
                table->symbol->index,
                table->symbol->name,
                objectTypeName[table->type],
                table->symbol->addr,
                table->symbol->lineno,
                table->symbol->func_sig
        );
        table = table->next;
        free(table->prev->symbol);
        free(table->prev);
    }
    printf("%-10d%-20s%-10s%-10ld%-10d%-10s\n",
        table->symbol->index,
        table->symbol->name,
        objectTypeName[table->type],
        table->symbol->addr,
        table->symbol->lineno,
        table->symbol->func_sig
    );
    free(table->symbol);
    free(table);
    scopeLevel --;
}

Object* findVariable(char* variableName){
    Object* variable = NULL;
    int lv = scopeLevel;
    while (lv >= 0){        
        Object *tmp = Head;
        while(tmp){
            if(!strcmp(tmp->symbol->name, variableName)){
                variable = tmp;
            }
            tmp = tmp->next;
        }
        lv --;
    }
    //if(variable)
    //printf("%s\n", variable->symbol->name);
    return variable;
}
void initVariable(ObjectType variableType){
    Object *tmp = Head;
    while(tmp){
        if(tmp->type == OBJECT_TYPE_UNDEFINED || tmp->type == OBJECT_TYPE_AUTO){
            tmp->type = variableType;
        }
        tmp = tmp->next;
    }  
}
Object* createVariable(ObjectType variableType, LinkedList* arraySubscripts, char* variableName, int value){
    Object *new_node = (Object *)malloc(sizeof(Object));
    new_node->symbol = (SymbolData *)malloc(sizeof(SymbolData));
    new_node->symbol->level = scopeLevel;
    new_node->symbol->index = idx;
    new_node->type = variableType;
    new_node->symbol->name = variableName;
    new_node->symbol->lineno = yylineno;
    new_node->symbol->func_sig = strdup("-");

    if(!value){
        ("> Insert `%s` (addr: %d) to scope level %d\n", variableName, variableAddress, scopeLevel);
        new_node->symbol->addr = variableAddress;
        variableAddress ++; 
    }
    else{
        ("> Insert `%s` (addr: -1) to scope level %d\n", variableName, scopeLevel);        
        new_node->symbol->addr = -1;  
    }   

    idx ++;
    if(Head){
        Tail->next = new_node;
        new_node->prev = Tail;
        Tail = new_node;
        Tail->next = NULL;
    }
    else{
        Head = new_node;
        Tail = new_node;
        Head->prev = NULL;
        Tail->next = NULL;
        Head->next = NULL;
        Tail->prev = NULL;
    }
    return NULL;
}

void functionLocalsBegin(){
    strcat(FuncDef->symbol->func_sig, ")");
    strcat(FuncDef->symbol->func_sig, objectJavaTypeName[FuncDef->type]);
    //printf("%s\n", FuncDef->symbol->func_sig);
    if(!strcmp(FuncDef->symbol->name, "main")){
        codeRaw(".method public static main([Ljava/lang/String;)V");
        codeRaw("\t.limit stack 100");
        codeRaw("\t.limit locals 100");   
    }
    else{        
        code(".method public static %s%s", FuncDef->symbol->name, FuncDef->symbol->func_sig);
        codeRaw("\t.limit stack 20");
        codeRaw("\t.limit locals 20");
    }
    FuncDef = NULL;
}
void functionParmPush(ObjectType variableType, LinkedList* arraySubscripts, char* variableName){
    createVariable(variableType, arraySubscripts, variableName, 0);
    strcat(FuncDef->symbol->func_sig, objectJavaTypeName[Tail->type]);
}
void functionBegin(ObjectType returnType, LinkedList* arraySubscripts, char* funcName){
    printf("func: %s\n", funcName);
    last_addr = variableAddress;
    createVariable(returnType, arraySubscripts, funcName, 1);
    FuncDef = Tail;
    if(!strcmp(funcName, "main")) {
        inMain = true;
        FuncDef->symbol->func_sig = strdup("([");
    }
    else {
        inMain = false;
        FuncDef->symbol->func_sig = strdup("(");
    }
    pushScope();
}
bool functionEnd(ObjectType returnType){
}

void returnObject(char* variableName){
    Object *obj = findVariable(variableName);
    ObjectType type = obj->type;
    if (type == OBJECT_TYPE_INT){
        if(!strcmp(variableName, "main")) codeRaw("\treturn");
        else codeRaw("\tireturn ");
    }
    else if (type == OBJECT_TYPE_FLOAT){
        codeRaw("\tfreturn ");
    }
    else if (type == OBJECT_TYPE_BOOL){
        codeRaw("\tireturn ");
    }
    else if (type == OBJECT_TYPE_CHAR){
        codeRaw("\tareturn ");
    }
    else if (type == OBJECT_TYPE_VOID){
        codeRaw("\treturn ");
    }
    else if (type == OBJECT_TYPE_STR){
        codeRaw("\tareturn ");
    }        
}
void doReturn(){
    toReturn = true;
    NoReturn = false;
}

bool checkMainReturn(){
    if(inMain && toReturn) return true;
    else return false;
}

bool checkMain(){
    if(inMain) return true;
    else return false;
}

bool checkReturn(){
    if(NoReturn) return false;
    else{
        NoReturn = true;
        return true;
    }
}

void functionArgsBegin(){
}
void functionArgPush(Object* obj){
}
void functionCall(char* funcName, Object* out);

void stdoutPrint(Object* obj){
    //printf("%d\n", obj->type);
    code("\tinvokevirtual java/io/PrintStream/print(%s)V\n", objectJavaTypeName[obj->type]);
}

void greaterlower(Object* obj, char *op){
    char compare[8] = "";
    if(obj->type == OBJECT_TYPE_INT) strcat(compare, "isub");
    else if(obj->type == OBJECT_TYPE_FLOAT) strcat(compare, "fcmpl");

    code("\t%s", compare);                        // compare
    code("\t%s L_cmp_%d", op, compare_cnt);       // jump to L_cmp_0 if op
    codeRaw("\ticonst_0");                        // compare result is false
    code("\tgoto L_cmp_%d", compare_cnt + 1);
    code("L_cmp_%d:", compare_cnt);             // if op, jump to here
    codeRaw("\ticonst_1");                        // compare result is true
    code("L_cmp_%d:", compare_cnt + 1);
    
    compare_cnt += 2;
}

void equalornot(char *op){                    
    code("\t%s L_eql_%d", op, equal_cnt);       
    codeRaw("\ticonst_0");                       
    code("\tgoto L_eql_%d", equal_cnt + 1);
    code("L_eql_%d:", equal_cnt);           
    codeRaw("\ticonst_1");                     
    code("L_eql_%d:", equal_cnt + 1);
    
    equal_cnt += 2;
}

void typeload(char* variableName){
    Object *obj = findVariable(variableName);
    //printf("%d(load type)\n", obj->type);
    if(obj != NULL){                
        //printf("%ld\n", obj->symbol->addr);
        if(obj->type == OBJECT_TYPE_BOOL) code("\tiload %" PRId64 " ; %s", obj->symbol->addr - last_addr, obj->symbol->name);
        else if(obj->type == OBJECT_TYPE_STR) code("\taload %" PRId64 " ; %s", obj->symbol->addr - last_addr, obj->symbol->name);
        else if(obj->type == OBJECT_TYPE_INT) code("\tiload %" PRId64 " ; %s", obj->symbol->addr - last_addr, obj->symbol->name);
        else if(obj->type == OBJECT_TYPE_FLOAT) code("\tfload %" PRId64 " ; %s", obj->symbol->addr - last_addr, obj->symbol->name);
    }
}
void typeStore(char* variableName){
    Object *obj = findVariable(variableName);
    //printf("%d(store type)\n", obj->type);
    //printf("%s(have name)\n", obj->symbol->name);
    if(obj != NULL){
        //printf("aa\n");
        //printf("%ld\n", obj->symbol->addr);   
        if(obj->type == OBJECT_TYPE_BOOL) code("\tistore %" PRId64 " ; %s", obj->symbol->addr - last_addr, obj->symbol->name);
        else if(obj->type == OBJECT_TYPE_STR) code("\tastore %" PRId64 " ; %s", obj->symbol->addr - last_addr, obj->symbol->name);
        else if(obj->type == OBJECT_TYPE_INT) code("\tistore %" PRId64 " ; %s", obj->symbol->addr - last_addr, obj->symbol->name);
        else if(obj->type == OBJECT_TYPE_FLOAT) code("\tfstore %" PRId64 " ; %s", obj->symbol->addr - last_addr, obj->symbol->name);
    }
}
void DeclStore(ObjectType type, Object* obj){
    //printf("%d(decl store type)\n", type);
    if(obj != NULL){    
        if(obj->type == OBJECT_TYPE_BOOL) code("\tistore %" PRId64 " ; %s", obj->symbol->addr - last_addr, obj->symbol->name);
        else if(obj->type == OBJECT_TYPE_STR) code("\tastore %" PRId64 " ; %s", obj->symbol->addr - last_addr, obj->symbol->name);
        else if(obj->type == OBJECT_TYPE_INT) code("\tistore %" PRId64 " ; %s", obj->symbol->addr - last_addr, obj->symbol->name);
        else if(obj->type == OBJECT_TYPE_FLOAT) code("\tfstore %" PRId64 " ; %s", obj->symbol->addr - last_addr, obj->symbol->name);
    }
}
void opassignment(Object* obj, char* op){
    typeload(obj->symbol->name);
    codeRaw("\tswap");
    code("\t%c%s", objectTypeName[obj->type][0], op);
    typeStore(obj->symbol->name);   
}
void logicassignment(Object* obj, char* op){
    typeload(obj->symbol->name);
    codeRaw("\tswap");
    code("\t%s", op);
    typeStore(obj->symbol->name);   
}

void CastVariable(ObjectType origintype, ObjectType castType){
    printf("Cast to %s\n", objectTypeName[castType]);
    if(castType != OBJECT_TYPE_BOOL && origintype != OBJECT_TYPE_BOOL)
    code("\t%c2%c", objectTypeName[origintype][0], objectTypeName[castType][0]);
}

void ifcondition(int flag){
    if(flag) {
        code("\tifeq L_if_%d", if_cnt);
    }
    else{
        code("\tgoto L_else_%d", else_cnt + 1);
        code("L_if_%d:", if_cnt);
        if_cnt ++;
    }
}
void elsecondition(int flag){
    if(flag) {
        code("L_else_%d:", else_cnt);
    }
    else{
        code("L_else_%d:", else_cnt + 1);
        else_cnt += 2;
    }

}

void loopwhilecondition(int flag){
    switch (flag) {
        case 1:
            code("L_while_%d:", while_cnt);
            break;
        case 2:
            code("\tifeq L_while_%d", while_cnt + 1);
            break;
        case 3:
            code("\tgoto L_while_%d", while_cnt);
            code("L_while_%d:", while_cnt + 1);
            while_cnt += 2;
            break;
        case 4:
            code("\tgoto L_while_%d", while_cnt + 1);
            break;
    }
}
void loopforcondition(int flag){
    switch (flag) {
        case 1:                                         /*forbegin*/
            for_cnt ++;
            cur_loop = for_cnt;
            code("L_for_%d:", for_cnt);
            break;
        case 2:                                         /*forbody*/
            code("L_for_body_%d:", for_cnt);
            break;
        case 3:                                         /*forend*/
            code("\tgoto L_for_update_%d", cur_loop);
            code("L_after_for_%d:", cur_loop);
            cur_loop --;
            break;
        case 4:                                         /*forbreak*/
            code("\tgoto L_after_for_%d", for_cnt);
            break;
        case 5:                                         /*forcondbegin*/
            code("L_for_cond_%d:", for_cnt);
            break;
        case 6:                                         /*forcondend*/
            code("\tifeq L_after_for_%d", for_cnt);
            code("\tgoto L_for_body_%d", for_cnt);
            break;
        case 7:                                         /*forupdatebegin*/
            code("L_for_update_%d:", for_cnt);
            break;
        case 8:                                         /*forupdateend*/
            code("\tgoto L_for_cond_%d", for_cnt);
            break;
    }
}
void breakLoop(int flag){
    if(flag){
        loopwhilecondition(4);
    }
    else{
        loopforcondition(4);
    }
}

void loadArr(char* variableName){
    Object *obj = findVariable(variableName);
    if(obj) code("\taload %" PRId64 " ; %s", obj->symbol->addr - last_addr, obj->symbol->name);
}

void storeArr(char* variableName){
    Object *obj = findVariable(variableName);
    if(obj) code("\tastore %" PRId64 " ; %s", obj->symbol->addr - last_addr, obj->symbol->name);
}

void createArr(ObjectType type, int flag){
    if(flag){        
        if(type == OBJECT_TYPE_INT){
            codeRaw("\tnewarray int");
        }
        else if(type == OBJECT_TYPE_FLOAT){
            codeRaw("\tnewarray float");
        }
    }
    else{
        if(type == OBJECT_TYPE_INT){
            codeRaw("\tmultianewarray [[I 2");
        }
        else if(type == OBJECT_TYPE_FLOAT){
            codeRaw("\tmultianewarray [[F 2");
        }
    }
}

// Expressions
bool objectExpression(char op, Object* a, Object* b, Object* out);
bool objectExpBinary(char op, Object* a, Object* b, Object* out);
bool objectExpBoolean(char op, Object* a, Object* b, Object* out);
bool objectNotBinaryExpression(Object* a, Object* out);
bool objectNotBooleanExpression(Object* a, Object* out);
bool objectNegExpression(Object* a, Object* out);
bool objectIncAssign(Object* a, Object* out);
bool objectDecAssign(Object* a, Object* out);
bool objectCast(ObjectType variableType, Object* a, Object* out);
bool objectExpAssign(char op, Object* dest, Object* val, Object* out);
bool objectValueAssign(Object* dest, Object* val, Object* out);

bool ifBegin(Object* a);
bool ifEnd();
bool ifOnlyEnd();
bool elseBegin();
bool elseEnd();

bool whileBegin();
bool whileBodyBegin();
bool whileEnd();

bool forBegin();
bool forInitEnd();
bool forConditionEnd(Object* result);
bool forHeaderEnd();
bool foreachHeaderEnd(Object* obj);
bool forEnd();

bool arrayCreate(Object* out);
bool objectArrayGet(Object* arr, LinkedList* arraySubscripts, Object* out);
LinkedList* arraySubscriptBegin(Object* index);
bool arraySubscriptPush(LinkedList* arraySubscripts, Object* index);
bool arraySubscriptEnd(LinkedList* arraySubscripts);

int main(int argc, char* argv[]) {
    char* outputFileName = NULL;
    if (argc == 3) {
        yyin = fopen(yyInputFileName = argv[1], "r");
        yyout = fopen(outputFileName = argv[2], "w");
    } else if (argc == 2) {
        yyin = fopen(yyInputFileName = argv[1], "r");
        yyout = stdout;
    } else {
        printf("require input file");
        exit(1);
    }
    if (!yyin) {
        printf("file `%s` doesn't exists or cannot be opened\n", yyInputFileName);
        exit(1);
    }
    if (!yyout) {
        printf("file `%s` doesn't exists or cannot be opened\n", outputFileName);
        exit(1);
    }

    codeRaw(".class public Main");
    codeRaw(".super java/lang/Object");
    scopeLevel = -1;

    yyparse();
    printf("Total lines: %d\n", yylineno);
    fclose(yyin);

    yylex_destroy();
    return 0;
}
