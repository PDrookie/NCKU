/* Definition section */
%{
    #include "compiler_util.h"
    #include "main.h"

    int yydebug = 1;
    ObjectType tempType = OBJECT_TYPE_INT;
    char *tempName = NULL;
    char *tempFuncName = NULL;    
    int isArray = 0, isMain = 0, isReturn = 0;
    int breakwhichLoop = 0;
    int arrayNumber = 0;
%}

/* Variable or self-defined structure */
%union {
    ObjectType var_type;

    bool b_var;
    char c_var;
    int32_t i_var;
    int64_t l_var;
    float f_var;
    double d_var;
    char *s_var;

    Object obj_val;

    //LinkList<Object*>
    LinkedList* array_subscript;
}

/* Token without return */
%token COUT
%token SHR SHL BAN BOR BNT BXO ADD SUB MUL DIV REM NOT GTR LES GEQ LEQ EQL NEQ LAN LOR
%token VAL_ASSIGN ADD_ASSIGN SUB_ASSIGN MUL_ASSIGN DIV_ASSIGN REM_ASSIGN BAN_ASSIGN BOR_ASSIGN BXO_ASSIGN SHR_ASSIGN SHL_ASSIGN INC_ASSIGN DEC_ASSIGN
%token IF ELSE FOR WHILE RETURN BREAK CONTINUE

/* Token with return, which need to sepcify type */
%token <var_type> VARIABLE_T
%token <b_var> BOOL_LIT
%token <c_var> CHAR_LIT
%token <i_var> INT_LIT
%token <f_var> FLOAT_LIT
%token <s_var> STR_LIT
%token <s_var> IDENT

/* Nonterminal with return, which need to sepcify type */
%type <obj_val> AssignmentStmt
%type <obj_val> AssignmentOperator
%type <obj_val> Variable 
%type <obj_val> CallFunction
//%type <obj_val> ArrayList
%type <obj_val> Expression
%type <obj_val> LogicExpression
%type <obj_val> OrExpression
%type <obj_val> AndExpression
%type <obj_val> BitOrExpression
%type <obj_val> BitXorExpression
%type <obj_val> BitAndExpression
%type <obj_val> EqualExpression
%type <obj_val> CompareExpression
%type <obj_val> ShiftExpression
%type <obj_val> AddOPExpression
%type <obj_val> MulOPExpression
%type <obj_val> CastExpression
%type <obj_val> PrimaryExpression
%type <obj_val> IdentExpression
//%type <obj_val> ArrayExpression
%type <obj_val> UnsignNumberExpression
%type <obj_val> LogicNotExpression
%type <obj_val> NumberExpression
%type <obj_val> BoolExpression
//%type <array_subscript> ArraySubscriptStmtList

%left ADD SUB
%left MUL DIV REM

%nonassoc CALL
%nonassoc THEN
%nonassoc ELSE

/* Yacc will start at this nonterminal */
%start Program

%%
/* Grammar section */

Program
    : { pushScope(); } GlobalStmtList { dumpScope(); }
    | /* Empty file */
;

GlobalStmtList 
    : GlobalStmtList GlobalStmt
    | GlobalStmt
;

GlobalStmt
    : DefineVariableStmt
    | FunctionDefStmt
;

DefineVariableStmt
    : VARIABLE_T IDENT VAL_ASSIGN Expression ';'
;

/* Function */
FunctionDefStmt
    : VARIABLE_T IDENT { functionBegin($<var_type>1, NULL, $<s_var>2); tempFuncName = $<s_var>2; isReturn = 0; isMain = 0; } '(' FunctionParameterStmtList ')' 
    { functionLocalsBegin(); } '{' StmtList '}' 
    {   
        if(!strcmp(tempFuncName, "main")) isMain = 1;
        if(isMain && !isReturn) codeRaw("\treturn");
        codeRaw(".end method\n");                 
        dumpScope(); 
    }
;

FunctionParameterStmtList 
    : FunctionParameterStmtList ',' FunctionParameterStmt
    | FunctionParameterStmt
    | /* Empty function parameter */
;
FunctionParameterStmt
    : VARIABLE_T IDENT { functionParmPush($<var_type>1, NULL, $<s_var>2); }
    | VARIABLE_T IDENT '[' ']' { functionParmPush($<var_type>1, NULL, $<s_var>2); }
;

/* Scope */
StmtList 
    : StmtList FunctionStmt
    | FunctionStmt
;

FunctionStmt
    : ';'
    | BodyStmt
    | AssignmentStmt ';'
    | DefineStmt ';'
    | IfStmt
    | LoopStmt
    | CallFunction
;

/*AssignmentOP*/
AssignmentStmt
    : IDENT { 
            Object *obj = findVariable($<s_var>1);
            if(obj){
                printf("IDENT (name=%s, address=%ld)\n", $1, obj->symbol->addr);
            }
            tempName = $<s_var>1;
      } AssignmentOperator { Object *obj = findVariable(tempName); tempType = obj->type; }
    | IDENT { loadArr($<s_var>1); tempName = $<s_var>1; isArray = 1; } ArrayIndices {
            Object *obj = findVariable($1);
            printf("IDENT (name=%s, address=%ld)\n", $1, obj->symbol->addr);
     } AssignmentOperator { Object *obj = findVariable(tempName); tempType = obj->type; codeRaw("\tiastore"); }
;

AssignmentOperator
    : VAL_ASSIGN Expression { 
                              printf("EQL_ASSIGN\n");                             
                              if ($<obj_val>2.type != tempType)
                                CastVariable($<obj_val>2.type, tempType);
                              if(isArray) isArray = 0;
                              else typeStore(tempName); 
                            }
    | ADD_ASSIGN Expression { 
                              printf("ADD_ASSIGN\n");                                                               
                              if ($<obj_val>2.type != tempType)
                                CastVariable($<obj_val>2.type, tempType);
                              Object *obj = findVariable(tempName); 
                              opassignment(obj, "add"); 
                            }
    | SUB_ASSIGN Expression { 
                              printf("SUB_ASSIGN\n");                               
                              if ($<obj_val>2.type != tempType)
                                CastVariable($<obj_val>2.type, tempType); 
                              Object *obj = findVariable(tempName); 
                              opassignment(obj, "sub");
                            }
    | MUL_ASSIGN Expression { 
                              printf("MUL_ASSIGN\n");                               
                              //if ($<obj_val>2.type != tempType)
                                //castVariable($<obj_val>2.type, tempType);
                              Object *obj = findVariable(tempName); 
                              opassignment(obj, "mul");     
                            }
    | DIV_ASSIGN Expression { 
                              printf("DIV_ASSIGN\n");                               
                              //if ($<obj_val>2.type != tempType)
                                //CastVariable($<obj_val>2.type, tempType);  
                              Object *obj = findVariable(tempName); 
                              opassignment(obj, "div");
                            }
    | REM_ASSIGN Expression { printf("REM_ASSIGN\n"); Object *obj = findVariable(tempName); logicassignment(obj, "irem"); }
    | SHR_ASSIGN Expression { printf("SHR_ASSIGN\n"); Object *obj = findVariable(tempName); logicassignment(obj, "iushr"); }
    | SHL_ASSIGN Expression { printf("SHL_ASSIGN\n"); Object *obj = findVariable(tempName); logicassignment(obj, "ishl"); }
    | BAN_ASSIGN Expression { printf("BAN_ASSIGN\n"); Object *obj = findVariable(tempName); logicassignment(obj, "iand"); }
    | BOR_ASSIGN Expression { printf("BOR_ASSIGN\n"); Object *obj = findVariable(tempName); logicassignment(obj, "ior"); }
    | BXO_ASSIGN Expression { printf("BXO_ASSIGN\n"); Object *obj = findVariable(tempName); logicassignment(obj, "ixor"); }
    | INC_ASSIGN {  printf("INC_ASSIGN\n"); 
                    Object *obj = findVariable(tempName);
                    typeload(tempName);
                    if(obj->type == OBJECT_TYPE_INT){
                        codeRaw("\ticonst_1");
                        codeRaw("\tiadd");
                    }
                    else{
                        codeRaw("\ficonst_1");
                        codeRaw("\tfadd");
                    }
                    typeStore(tempName);
                 }
    | DEC_ASSIGN {  printf("DEC_ASSIGN\n"); 
                    Object *obj = findVariable(tempName);
                    typeload(tempName);
                    if(obj->type == OBJECT_TYPE_INT){
                        codeRaw("\ticonst_1");
                        codeRaw("\tisub");
                    }
                    else{
                        codeRaw("\ficonst_1");
                        codeRaw("\tfsub");
                    }
                    typeStore(tempName);
                 }
;

/* IfElse */
IfStmt
    : IF '(' Expression ')' { ifcondition(1); } { printf("IF\n"); pushScope(); } '{' StmtList '}' { ifcondition(0); } { dumpScope(); } ElseStmt
    | IF '(' Expression ')' { ifcondition(1); } { printf("IF\n"); } FunctionStmt { ifcondition(0); } ElseStmt
;

ElseStmt
    : ELSE { elsecondition(1); } { printf("ELSE\n"); pushScope(); } '{' StmtList '}' { elsecondition(0); } { dumpScope(); }
    | { elsecondition(1); elsecondition(0); } /* Empty else */ 
;

/* Loop */
LoopStmt
    : WhileStmt
    | ForStmt
;

WhileStmt
    : WHILE { printf("WHILE\n"); breakwhichLoop = 1; } { loopwhilecondition(1); } '(' Expression ')' { loopwhilecondition(2); } { pushScope(); } '{' StmtList '}' { loopwhilecondition(3); } { dumpScope(); }
;

ForStmt
    : FOR { printf("FOR\n"); breakwhichLoop = 0; } { loopforcondition(1); } { pushScope(); } '(' ForDefine ')' { loopforcondition(2); } '{' StmtList { loopforcondition(3); } '}' { dumpScope(); }
;

ForDefine
    : InitDefine ';' IterativeCondition ';' IterativeUpdate 
    | DefineStmt ':' Expression { tempType = $<var_type>3; }
;

InitDefine
    : DefineStmt
    | AssignmentStmt
    | /* Empty for init */
;

IterativeCondition
    : { loopforcondition(5); } Expression { loopforcondition(6); }
    | /* Empty for Condition */
;

IterativeUpdate
    : { loopforcondition(7); } AssignmentStmt { loopforcondition(8); }
    | /* Empty for Iterative */
;

/* Define */
DefineStmt
    : VARIABLE_T { tempType = $<var_type>1; } DefineVariables
;

DefineVariables
    : DefineVariables ',' Variable
    | Variable
;

Variable
    : IDENT { createVariable(tempType, NULL, $<s_var>1, 0); }
    | IDENT VAL_ASSIGN Expression { createVariable($<obj_val>3.type, NULL, $<s_var>1, 0); 
                                    tempType = $<obj_val>3.type;
                                    Object *obj = findVariable($<s_var>1);
                                    DeclStore($<obj_val>3.type, obj); 
                                    if ($<obj_val>3.type != tempType)
                                        CastVariable($<obj_val>3.type, tempType);
                                  }
    | IDENT '[' NumberExpression ']' { 
        createArr(tempType, 1);
        printf("create array: %d\n", arrayNumber); 
        arrayNumber = 0;    
        createVariable(tempType, NULL, $<s_var>1, 0); 
        storeArr($<s_var>1);  
    }
    | IDENT '[' NumberExpression ']' VAL_ASSIGN 
      { createArr(tempType, 1); } '{' ArrayList '}' { 
        printf("create array: %d\n", arrayNumber); 
        arrayNumber = 0;      
        createVariable(tempType, NULL, $<s_var>1, 0);
        storeArr($<s_var>1); 
    }    
    | IDENT '[' NumberExpression ']' '[' NumberExpression ']' {  
        createArr(tempType, 0);
        createVariable(tempType, NULL, $<s_var>1, 0);
        printf("create array: %d\n", arrayNumber);   
        arrayNumber = 0;   
        storeArr($<s_var>1);  
    } 
;

ArrayList
    : ArrayList ',' { codeRaw("\tdup"); code("\tldc %d", arrayNumber); } Expression { arrayNumber ++; codeRaw("\tiastore"); }
    | { codeRaw("\tdup"); code("\tldc %d", arrayNumber); } Expression { arrayNumber ++; codeRaw("\tiastore"); }
    | /* Empty array list */
;

BodyStmt
    : COUT CoutParmListStmt ';'
    | ReturnCondition    
    | BREAK ';' { breakLoop(breakwhichLoop); }
    | CONTINUE ';' { printf("CONTINUE\n"); }
;

CoutParmListStmt
    : CoutParmListStmt SHL { codeRaw("\tgetstatic java/lang/System/out Ljava/io/PrintStream;"); } Expression { stdoutPrint(&$<obj_val>4); }
    | SHL { codeRaw("\tgetstatic java/lang/System/out Ljava/io/PrintStream;"); } Expression { stdoutPrint(&$<obj_val>3); }
;

ReturnCondition
    : RETURN { isReturn = 1; if(!strcmp(tempFuncName, "main")) isMain = 1; } Expression ';' { printf("RETURN\n"); returnObject(tempFuncName); }
    | RETURN { isReturn = 1; if(!strcmp(tempFuncName, "main")) isMain = 1; } { printf("RETURN\n"); returnObject(tempFuncName); }
;

/*expression*/
Expression
    : LogicExpression
;

LogicExpression
    : OrExpression { $$ = $1; }
;

OrExpression
    : OrExpression LOR AndExpression { 
        // bool check
        printf("LOR\n"); 
        codeRaw("\tior");
        $$ = $3; 
      }
    | AndExpression { $$ = $1; }
;

AndExpression
    : AndExpression LAN BitOrExpression { 
        // bool check
        printf("LAN\n");
        codeRaw("\tiand");
        $$ = $3; 
      }
    | BitOrExpression { $$ = $1; }
;

BitOrExpression
    : BitOrExpression BOR BitXorExpression { 
        // bool check
        printf("BOR\n"); 
        codeRaw("\tior");
        $$ = $3; 
      } 
    | BitXorExpression { $$ = $1; }
;

BitXorExpression
    : BitXorExpression BXO BitAndExpression { 
        // bool check
        printf("BXO\n"); 
        codeRaw("\tixor");
        $$ = $3; 
      } 
    | BitAndExpression { $$ = $1; }
;

BitAndExpression
    : BitAndExpression BAN EqualExpression { 
        // bool check
        printf("BAN\n"); 
        codeRaw("\tiand");
        $$ = $3; 
      }
    | EqualExpression { $$ = $1; }
;

EqualExpression
    : EqualExpression NEQ CompareExpression { 
        // bool check
        printf("NEQ\n"); 
        equalornot("if_icmpne");
        $$ = $3; 
      }
    | EqualExpression EQL CompareExpression { 
        // bool check
        printf("EQL\n"); 
        equalornot("if_icmpeq");
        $$ = $3; 
      } 
    | CompareExpression { $$ = $1; }
;

CompareExpression
    : CompareExpression GTR ShiftExpression { 
        // bool check
        printf("GTR\n"); 
        greaterlower(&$<obj_val>1, "ifgt");
        $$ = $3; 
      }
    | CompareExpression LES ShiftExpression { 
        // bool check
        printf("LES\n"); 
        greaterlower(&$<obj_val>1, "iflt");
        $$ = $3; 
      }
    | CompareExpression GEQ ShiftExpression { 
        // bool check
        printf("GEQ\n"); 
        greaterlower(&$<obj_val>1, "ifge");
        $$ = $3; 
      }
    | CompareExpression LEQ ShiftExpression { 
        // bool check
        printf("LEQ\n"); 
        greaterlower(&$<obj_val>1, "ifle");
        $$ = $3; 
      }
    | ShiftExpression { $$ = $1; }
;

ShiftExpression
    : ShiftExpression SHR AddOPExpression { 
        // bool check
        printf("SHR\n"); 
        codeRaw("\tiushr");
        $$ = $3; 
      }
    | AddOPExpression { $$ = $1; }
;

AddOPExpression
    : AddOPExpression ADD MulOPExpression { 
        // bool check
        printf("ADD\n");
        if($1.type == OBJECT_TYPE_FLOAT) codeRaw("\tfadd");
        else codeRaw("\tiadd");
        $$ = $3; 
      }
    | AddOPExpression SUB MulOPExpression { 
        // bool check
        printf("SUB\n"); 
        if($1.type == OBJECT_TYPE_FLOAT) codeRaw("\tfsub");
        else codeRaw("\tisub");
        $$ = $3; 
      }
    | MulOPExpression { $$ = $1; }
;

MulOPExpression
    : MulOPExpression MUL CastExpression { 
        // bool check
        printf("MUL\n"); 
        if($1.type == OBJECT_TYPE_FLOAT) codeRaw("\tfmul");
        else codeRaw("\timul");
        $$ = $3; 
      } 
    | MulOPExpression DIV CastExpression { 
        // bool check
        printf("DIV\n"); 
        if($1.type == OBJECT_TYPE_FLOAT) codeRaw("\tfdiv");
        else codeRaw("\tidiv");
        $$ = $3; 
      } 
    | MulOPExpression REM CastExpression { 
        // bool check
        printf("REM\n"); 
        codeRaw("\tirem");
        $$ = $3; 
      } 
    | CastExpression { $$ = $1; }
;

CastExpression
    : '(' VARIABLE_T ')' UnsignNumberExpression { 
        // bool check
        CastVariable($4.type, $<var_type>2);
        $$.type = $<var_type>2;
      } 
    | UnsignNumberExpression { $$ = $1; }
;

UnsignNumberExpression
    : SUB UnsignNumberExpression { 
        // bool check
        printf("NEG\n"); 
        if($2.type == OBJECT_TYPE_INT) codeRaw("\tineg");
        else codeRaw("\tfneg");
        $$ = $2; 
      }
    | NOT UnsignNumberExpression { 
        // bool check
        printf("NOT\n"); 
        codeRaw("\ticonst_1");
        codeRaw("\tixor");
        $$ = $2; 
      }
    | LogicNotExpression { $$ = $1; }
;

LogicNotExpression
    : BNT LogicNotExpression { 
        // bool check
        printf("BNT\n"); 
        codeRaw("\ticonst_m1");
        codeRaw("\tixor");
        $$ = $2; 
      }
    | BAN LogicNotExpression { 
        // bool check
        printf("BAN\n"); 
        codeRaw("\tiand");
        $$ = $2; 
      }
    | PrimaryExpression { $$ = $1; }
;

PrimaryExpression
    : '(' Expression ')' { $$ = $2; }                    
    | CallFunction { $$ = $1; }
    | CHAR_LIT  {   printf("CHAR_LIT \'%c\'\n", $1);              
                    code("\tldc %d", $1);
                    $$.type = OBJECT_TYPE_CHAR; }
    | STR_LIT   {   printf("STR_LIT \"%s\"\n", $1);              
                    code("\tldc \"%s\"", $1);
                    $$.type = OBJECT_TYPE_STR; }
    | IdentExpression    
    | BoolExpression
    | NumberExpression
    | ArrayExpression { $$.type = tempType; }
;

CallFunction
    : IDENT '(' FunctionList ')' {
        Object *obj = findVariable($1);
        printf("IDENT (name=%s, address=%ld)\n", $<s_var>1, obj->symbol->addr);
        printf("call: %s%s\n", obj->symbol->name, obj->symbol->func_sig);
        $$.type = obj->type;
        code("\tinvokestatic Main/%s%s", obj->symbol->name, obj->symbol->func_sig);
    }
;

FunctionList
    : FunctionList ',' Expression 
    | Expression
    | /* Empty array list */
;

IdentExpression
    : IDENT { 
            Object *obj = findVariable($<s_var>1);
            if(obj){
                printf("IDENT (name=%s, address=%ld)\n", $1, obj->symbol->addr);
                typeload($<s_var>1);                
                $$.symbol = (SymbolData*)malloc(sizeof(SymbolData));
                $$.symbol->name = $<s_var>1;
                $$.type = obj->type;
            }
            else{
                printf("IDENT (name=%s, address=-1)\n", $1);
                codeRaw("\tldc \"\n\"");
                $$.type = OBJECT_TYPE_STR;
            }
      }    
;

ArrayExpression
    : IDENT { loadArr($<s_var>1); } ArrayIndices {
            Object *obj = findVariable($1);
            printf("IDENT (name=%s, address=%ld)\n", $1, obj->symbol->addr);
            tempType = obj->type;
     } { codeRaw("\tiaload"); }  
;

ArrayIndices
    : ArrayIndices '[' { codeRaw("\taaload"); } Expression ']'   /* construct 2D array */
    | '[' Expression ']' /* construct 1D array */
;


NumberExpression
    : INT_LIT   {  printf("INT_LIT %d\n", $1);
                   if(!(isMain && isReturn)) {
                       code("\tldc %d", $1);
                   }
                   else{
                       isMain = 0;
                       isReturn = 0;
                   }
                   $$.type = OBJECT_TYPE_INT;   }
    | FLOAT_LIT {  printf("FLOAT_LIT %f\n", $1);
                   code("\tldc %f", $1);
                   $$.type = OBJECT_TYPE_FLOAT; }
;

BoolExpression
    : BOOL_LIT {   printf("BOOL_LIT %s\n", $1 ? "TRUE" : "FALSE");
                   code("\ticonst_%d", $1 ? 1 : 0);                    
                   $$.type = OBJECT_TYPE_BOOL; }
;

%%
/* C code section */
