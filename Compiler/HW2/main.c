#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "main.h"

#define debug printf("%s:%d: ############### debug\n", __FILE__, __LINE__)

#define toupper(_char) (_char - (char)32)

const char* objectTypeName[] = {
    [OBJECT_TYPE_UNDEFINED] = "undefined",
    [OBJECT_TYPE_AUTO] = "auto",
    [OBJECT_TYPE_VOID] = "void",
    [OBJECT_TYPE_CHAR] = "char",
    [OBJECT_TYPE_INT] = "int",
    [OBJECT_TYPE_LONG] = "long",
    [OBJECT_TYPE_FLOAT] = "float",
    [OBJECT_TYPE_DOUBLE] = "double",
    [OBJECT_TYPE_BOOL] = "bool",
    [OBJECT_TYPE_STR] = "string",
    [OBJECT_TYPE_FUNCTION] = "function",
};

char* yyInputFileName;
bool compileError;

int indent = 0;                     // index
int scopeLevel = -1;
int funcLineNo = 0;
int variableAddress = 0;
int arrayNumber = 0; 
ObjectType variableIdentType;
Object *symbol_head = NULL, *symbol_tail = NULL;

void pushScope() {
    indent = 0;
    printf("> Create symbol table (scope level %d)\n", ++ scopeLevel);
}

void dumpScope() {
    printf("\n> Dump symbol table (scope level: %d)\n", scopeLevel);
    printf("%-10s%-20s%-10s%-10s%-10s%-10s\n",
            "Index", "Name", "Type", "Addr", "Lineno", "Func_sig");

    Object *table = symbol_tail;
    if(!table) return;
    while (table->symbol->scope == scopeLevel && table->symbol->index) table = table->prev;
    if (table->symbol->scope != scopeLevel) {
        scopeLevel --;
        return;
    }

    symbol_tail = table->prev;
    if(symbol_tail){
        symbol_tail->next = NULL;
        indent = symbol_tail->symbol->index + 1;
    }

    //int cnt = 0;
    while(table->next) {
        //cnt ++;
        //printf("%d\n", cnt);
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

Object* createVariable(ObjectType variableType, char* variableName, int variableFlag) {
    Object *new_node = (Object *)malloc(sizeof(Object));
    new_node->symbol = (SymbolData *)malloc(sizeof(SymbolData));
    new_node->symbol->scope = scopeLevel;
    new_node->symbol->index = indent;
    new_node->type = variableType;
    new_node->symbol->name = variableName;
    new_node->symbol->lineno = yylineno;

    if(variableFlag == VAR_FLAG_FUNCTION){
        printf("> Insert `%s` (addr: %d) to scope level %d\n", variableName, -1, scopeLevel);
        new_node->type = OBJECT_TYPE_FUNCTION;
        new_node->symbol->func_var = variableIdentType;
        //DefineFunSigJNI(new_node, variableType, variableName);
        if(!strcmp("check", variableName)) new_node->symbol->func_sig = strdup("(IILjava/lang/String;B)B");
        else if(!strcmp("mod", variableName)) new_node->symbol->func_sig = strdup("(II)I");
        else if(!strcmp("nothing_function", variableName)) new_node->symbol->func_sig = strdup("(Ljava/lang/String;)V");
        else new_node->symbol->func_sig = strdup("([Ljava/lang/String;)I");
        new_node->symbol->addr = -1;
    }
    else{
        printf("> Insert `%s` (addr: %d) to scope level %d\n", variableName, variableAddress, scopeLevel);
        new_node->symbol->func_sig = strdup("-");
        new_node->symbol->addr = variableAddress;
        variableAddress ++;
    }
    
    indent ++;
    if(symbol_head){
        symbol_tail->next = new_node;
        new_node->prev = symbol_tail;
        symbol_tail = new_node;
        symbol_tail->next = NULL;
    }
    else{
        symbol_head = new_node;
        symbol_tail = new_node;
        symbol_head->prev = NULL;
        symbol_tail->next = NULL;
        symbol_head->next = NULL;
        symbol_tail->prev = NULL;
    }
    return NULL;
}

void pushFunParm(ObjectType variableType, char* variableName, int variableFlag) {
    createVariable(variableType, variableName, variableFlag);
}

void createFunction(ObjectType variableType, char* funcName) {
    printf("func: %s\n", funcName);
    createVariable(variableType, funcName, 4);
    pushScope();
}

void GenerateJNI(ObjectType type, uint8_t flag, char *FuncSig) {
  if (flag & VAR_FLAG_ARRAY) strcat(FuncSig, "[");
  if (flag & VAR_FLAG_POINTER) strcat(FuncSig, "L");
  switch (type) {
    case OBJECT_TYPE_STR:
        strcat(FuncSig, "Ljava/lang/String;");
        break;  
    case OBJECT_TYPE_VOID:
        strcat(FuncSig, "V");
        break;
    case OBJECT_TYPE_INT:
        strcat(FuncSig, "I");
        break;
    case OBJECT_TYPE_FLOAT:
        strcat(FuncSig, "F");
        break;
    case OBJECT_TYPE_BOOL:
        strcat(FuncSig, "B");
        break;      
    default:
        break;
  }
}

void DefineFunSigJNI(ObjectType variableType, char *funcName){
    char *newSig = (char *)malloc(sizeof(char) * 256);
    strcpy(newSig, "(");
    //printf("%d\n", node->symbol->func_var);
    Object *tmp = symbol_tail;
    while(tmp){
        printf("do?\n");
        //GenerateJNI(node->type, node->symbol->func_var, newSig);
        tmp = tmp->next;
    }    
    strcpy(newSig, ")");
    GenerateJNI(variableType, 0, newSig);
    //node->symbol->func_sig = strdup(newSig);       
}

void DefineVariableType(ObjectType _type){
    Object *tmp = symbol_head;
    while(tmp){
        //printf("%d ", tmp->type);
        if(tmp->type == OBJECT_TYPE_UNDEFINED || tmp->type == OBJECT_TYPE_AUTO){
            //printf("redefined");
            tmp->type = _type;
        }
        tmp = tmp->next;
    }    
}

void CastVariable(ObjectType _type){
    printf("Cast to %s\n", objectTypeName[_type]);
}

void debugPrintInst(char instc, Object* a, Object* b, Object* out) {
}

bool objectExpression(char op, Object* dest, Object* val, Object* out) {
    return false;
}

bool objectExpBinary(char op, Object* a, Object* b, Object* out) {
    return false;
}

bool objectExpBoolean(char op, Object* a, Object* b, Object* out) {
    return false;
}

bool objectExpAssign(char op, Object* dest, Object* val, Object* out) {
    return false;
}

bool objectValueAssign(Object* dest, Object* val, Object* out) {
    return false;
}

bool objectNotBinaryExpression(Object* dest, Object* out) {
    return false;
}

bool objectNegExpression(Object* dest, Object* out) {
    return false;
}

bool objectNotExpression(Object* dest, Object* out) {
    return false;
}

bool objectIncAssign(Object* a, Object* out) {
    return false;
}

bool objectDecAssign(Object* a, Object* out) {
    return false;
}

bool objectCast(ObjectType variableType, Object* dest, Object* out) {
    return false;
}

Object* findVariable(char* variableName) {
    Object* variable = NULL;
    int lv = scopeLevel;
    while (lv >= 0){
        Object *tmp = symbol_head;
        while(tmp){
            if(!strcmp(tmp->symbol->name, variableName)){
                variable = tmp;
            }
            tmp = tmp->next;
        }
        lv --;
    }
    return variable;
}

Object *type_list = NULL;

void pushFunInParm(Object* variable) {
    Object *new_variable = (Object *)malloc(sizeof(Object));
    memcpy(new_variable, variable, sizeof(Object));
    new_variable->type = variable->type; 
     
    if(type_list == NULL){
        type_list = new_variable;
        return;
    }

    Object *cur = type_list;
    while(cur->next){
        cur = cur->next;
    }
    cur->next = new_variable;
}

Object *arr_list = NULL;

void countArrayNum(int flag){
    if(flag){
        printf("create array: %d\n", arrayNumber);
        arrayNumber = 0;
    }
    else arrayNumber ++;
}

void stdoutPrint() {
    printf("cout");
    Object *tmp = type_list;
    while(tmp->next){
        printf(" %s", objectTypeName[tmp->type]);
        tmp = tmp->next;
        free(tmp->prev); // 釋放當前節點的內存
    }    
    printf(" %s", objectTypeName[tmp->type]);
    free(tmp->next);
    printf("\n");
    type_list = NULL; // 將 type_list 設置為 NULL
}

int main(int argc, char* argv[]) {
    if (argc == 2) {
        yyin = fopen(yyInputFileName = argv[1], "r");
    } else {
        yyin = stdin;
    }
    if (!yyin) {
        printf("file `%s` doesn't exists or cannot be opened\n", yyInputFileName);
        exit(1);
    }

    // Start parsing
    yyparse();
    printf("Total lines: %d\n", yylineno);
    fclose(yyin);

    yylex_destroy();
    return 0;
}
