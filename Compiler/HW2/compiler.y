/* Definition section */
%{
    #include "compiler_common.h"
    #include "compiler_util.h"
    #include "main.h"

    int yydebug = 1;
%}

/* Variable or self-defined structure */
%union {
    ObjectType var_type;

    bool b_var;
    int i_var;
    float f_var;
    char *s_var;

    Object object_val;
}

/* Token without return */
%token COUT
%token SHR SHL BAN BOR BNT BXO ADD SUB MUL DIV REM NOT GTR LES GEQ LEQ EQL NEQ LAN LOR
%token VAL_ASSIGN ADD_ASSIGN SUB_ASSIGN MUL_ASSIGN DIV_ASSIGN REM_ASSIGN BAN_ASSIGN BOR_ASSIGN BXO_ASSIGN SHR_ASSIGN SHL_ASSIGN INC_ASSIGN DEC_ASSIGN
%token IF ELSE FOR WHILE RETURN BREAK CONTINUE
%token '{' '}' '(' ')' '[' ']'
%token ',' ':' ';'

/* Token with return, which need to sepcify type */
%token <var_type> VARIABLE_T
%token <b_var> BOOL_LIT
%token <i_var> INT_LIT
%token <f_var> FLOAT_LIT
%token <s_var> STR_LIT
%token <s_var> IDENT

/* Nonterminal with return, which need to sepcify type */
%type <object_val> Variable 
%type <object_val> CallFunction
%type <object_val> ArrayList
%type <object_val> Expression
%type <object_val> LogicExpression
%type <object_val> OrExpression
%type <object_val> AndExpression
%type <object_val> BitOrExpression
%type <object_val> BitXorExpression
%type <object_val> BitAndExpression
%type <object_val> EqualExpression
%type <object_val> CompareExpression
%type <object_val> ShiftExpression
%type <object_val> AddOPExpression
%type <object_val> MulOPExpression
%type <object_val> CastExpression
%type <object_val> PrimaryExpression
%type <object_val> IdentExpression
%type <object_val> UnsignNumberExpression
%type <object_val> LogicNotExpression
%type <object_val> NumberExpression
%type <object_val> BoolExpression

/* Prefix */
%left ADD SUB
%left MUL DIV REM

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
    : VARIABLE_T IDENT { createFunction($<var_type>1, $<s_var>2); } '(' FunctionParameterStmtList ')''{' StmtList '}' { dumpScope(); }
    | VARIABLE_T IDENT '[' ']' { createFunction($<var_type>1, $<s_var>2); } '(' FunctionParameterStmtList ')' '{' StmtList '}' { dumpScope(); }

;
FunctionParameterStmtList 
    : FunctionParameterStmtList ',' FunctionParameterStmt
    | FunctionParameterStmt
    | /* Empty function parameter */
;
FunctionParameterStmt
    : VARIABLE_T IDENT { pushFunParm($<var_type>1, $<s_var>2, VAR_FLAG_DEFAULT); }
    | VARIABLE_T IDENT '[' ']' { pushFunParm($<var_type>1, $<s_var>2, VAR_FLAG_ARRAY); }
;

FunctionList
    : FunctionList ',' Expression 
    | Expression
    | /* Empty array list */
;

/* Scope */
StmtList 
    : StmtList FunctionStmt
    | FunctionStmt
;

FunctionStmt
    : ';'
    | Stmt
    | AssignmentStmt ';'
    | DefineStmt ';'
    | IfStmt
    | LoopStmt
;

AssignmentStmt
    : IdentExpression VAL_ASSIGN Expression { printf("EQL_ASSIGN\n"); }
    | IdentExpression ADD_ASSIGN Expression { printf("ADD_ASSIGN\n"); }
    | IdentExpression SUB_ASSIGN Expression { printf("SUB_ASSIGN\n"); }
    | IdentExpression MUL_ASSIGN Expression { printf("MUL_ASSIGN\n"); }
    | IdentExpression DIV_ASSIGN Expression { printf("DIV_ASSIGN\n"); }
    | IdentExpression REM_ASSIGN Expression { printf("REM_ASSIGN\n"); }
    | IdentExpression SHR_ASSIGN Expression { printf("SHR_ASSIGN\n"); }
    | IdentExpression SHL_ASSIGN Expression { printf("SHL_ASSIGN\n"); }
    | IdentExpression BAN_ASSIGN Expression { printf("BAN_ASSIGN\n"); }
    | IdentExpression BOR_ASSIGN Expression { printf("BOR_ASSIGN\n"); }
    | IdentExpression BXO_ASSIGN Expression { printf("BXO_ASSIGN\n"); }
    | IdentExpression INC_ASSIGN { printf("INC_ASSIGN\n"); }
    | IdentExpression DEC_ASSIGN { printf("DEC_ASSIGN\n"); }
;

IfStmt
    : IF '(' Expression ')' { printf("IF\n"); pushScope(); } '{' StmtList '}' { dumpScope(); } ElseStmt
    | IF '(' Expression ')' { printf("IF\n"); } FunctionStmt
;

ElseStmt
    : ELSE { printf("ELSE\n"); pushScope(); } '{' StmtList '}' { dumpScope(); }
    | /* Empty else */
;

LoopStmt
    : WhileStmt
    | ForStmt
;

WhileStmt
    : WHILE { printf("WHILE\n"); } '(' Expression ')' { pushScope(); } '{' StmtList '}' { dumpScope(); }
;

ForStmt
    : FOR { printf("FOR\n"); pushScope(); } '(' ForDefine ')' '{' StmtList '}' { dumpScope(); }
;

ForDefine
    : InitDefine ';' Expression ';' IterativeDefine 
    | DefineStmt ':' Expression { DefineVariableType($<var_type>3); }
;

InitDefine
    : DefineStmt
    | AssignmentStmt
    | /* Empty for init */
;

IterativeDefine
    : AssignmentStmt
    | /* Empty for Iterative */
;

DefineStmt
    : VARIABLE_T DefineVariables { DefineVariableType($<var_type>1); }
;

DefineVariables
    : DefineVariables ',' Variable
    | Variable
;

Variable
    : IDENT { createVariable(OBJECT_TYPE_UNDEFINED, $<s_var>1, VAR_FLAG_DEFAULT); }
    | IDENT VAL_ASSIGN Expression { createVariable($3.type, $<s_var>1, VAR_FLAG_DEFAULT); }
    | IDENT '[' NumberExpression ']' '[' NumberExpression ']' { createVariable(OBJECT_TYPE_UNDEFINED, $<s_var>1, VAR_FLAG_ARRAY); }
    | IDENT '[' NumberExpression ']' VAL_ASSIGN '{' ArrayList '}' { 
        countArrayNum(1);         
        //Object *obj = findVariable($1);
        createVariable(OBJECT_TYPE_UNDEFINED, $<s_var>1, VAR_FLAG_ARRAY); 
      }
;

ArrayList
    : ArrayList ',' Expression { countArrayNum(0); $$ = $3; }
    | Expression { countArrayNum(0); $$ = $1;}
    | /* Empty array list */
;

Stmt
    : COUT CoutParmListStmt ';' { stdoutPrint(); }
    | ReturnCondition
    | BREAK ';' { printf("BREAK\n"); }
    | CONTINUE ';' { printf("CONTINUE\n"); }
    | CallFunction
;

CoutParmListStmt
    : CoutParmListStmt SHL Expression { pushFunInParm(&$3); }
    | SHL Expression { pushFunInParm(&$2); }
;

ReturnCondition
    : RETURN Expression ';' { printf("RETURN\n"); }
    | RETURN ';' { printf("RETURN\n"); }
;

/*expression*/
Expression
    : LogicExpression
;

LogicExpression
    : OrExpression { $$ = $1; }
;

OrExpression
    : OrExpression LOR AndExpression { printf("LOR\n"); $$ = $3; }
    | AndExpression { $$ = $1; }
;

AndExpression
    : AndExpression LAN BitOrExpression { printf("LAN\n"); $$ = $3; }
    | BitOrExpression { $$ = $1; }
;

BitOrExpression
    : BitOrExpression BOR BitXorExpression { printf("BOR\n"); $$ = $3; }
    | BitXorExpression { $$ = $1; }
;

BitXorExpression
    : BitXorExpression BXO BitAndExpression { printf("BXO\n"); $$ = $3; }
    | BitAndExpression { $$ = $1; }
;

BitAndExpression
    : BitAndExpression BAN EqualExpression { printf("BAN\n"); $$ = $3; }
    | EqualExpression { $$ = $1; }
;

EqualExpression
    : EqualExpression NEQ CompareExpression { printf("NEQ\n"); $$ = $3; }
    | EqualExpression EQL CompareExpression { printf("EQL\n"); $$ = $3; }
    | CompareExpression { $$ = $1; }
;

CompareExpression
    : CompareExpression GTR ShiftExpression { printf("GTR\n"); $$ = $3; }
    | CompareExpression LES ShiftExpression { printf("LES\n"); $$ = $3; }
    | CompareExpression GEQ ShiftExpression { printf("GEQ\n"); $$ = $3; }
    | CompareExpression LEQ ShiftExpression { printf("LEQ\n"); $$ = $3; }
    | ShiftExpression { $$ = $1; }
;

ShiftExpression
    : ShiftExpression SHR AddOPExpression { printf("SHR\n"); $$ = $3; }
    | AddOPExpression { $$ = $1; }
;

AddOPExpression
    : AddOPExpression ADD MulOPExpression { printf("ADD\n"); $$ = $3; }
    | AddOPExpression SUB MulOPExpression { printf("SUB\n"); $$ = $3; }
    | MulOPExpression { $$ = $1; }
;

MulOPExpression
    : MulOPExpression MUL CastExpression { printf("MUL\n"); $$ = $3;}
    | MulOPExpression DIV CastExpression { printf("DIV\n"); $$ = $3;}
    | MulOPExpression REM CastExpression { printf("REM\n"); $$ = $3;}
    | CastExpression { $$ = $1; }
;

CastExpression
    : '('VARIABLE_T')' UnsignNumberExpression { CastVariable($<var_type>2); $$.type = $<var_type>2;}
    | UnsignNumberExpression { $$ = $1; }
;

UnsignNumberExpression
    : SUB UnsignNumberExpression { printf("NEG\n"); $$ = $2; }
    | NOT UnsignNumberExpression { printf("NOT\n"); $$ = $2; }
    | LogicNotExpression { $$ = $1; }
;

LogicNotExpression
    : BNT LogicNotExpression { printf("BNT\n"); $$ = $2; }
    | BAN LogicNotExpression { printf("BAN\n"); $$ = $2; }
    | CallFunction { $$ = $1; }
    | PrimaryExpression { $$ = $1; }
;

CallFunction
    : IDENT '(' FunctionList ')' {
        Object *obj = findVariable($1);
        printf("IDENT (name=%s, address=%ld)\n", $1, obj->symbol->addr);
        printf("call: %s%s\n", obj->symbol->name, obj->symbol->func_sig);
        if(!strcmp("check", obj->symbol->name)) $$.type = OBJECT_TYPE_BOOL;
        else $$.type = OBJECT_TYPE_INT;
    }
;

PrimaryExpression
    : '(' Expression ')' { $$ = $2; }
    | STR_LIT   { printf("STR_LIT \"%s\"\n", $1); $$.type = OBJECT_TYPE_STR; }
    | IdentExpression    
    | BoolExpression
    | NumberExpression
;

IdentExpression
    : IDENT { 
            Object *obj = findVariable($1);
            if(obj){
                printf("IDENT (name=%s, address=%ld)\n", $1, obj->symbol->addr); 
                $$.type = obj->type;
            }
            else{                
                printf("IDENT (name=%s, address=-1)\n", $1); 
                $$.type = OBJECT_TYPE_STR;
            }
      } 
    | IDENT '[' Expression ']' {
            Object *obj = findVariable($1);
            printf("IDENT (name=%s, address=%ld)\n", $1, obj->symbol->addr);
            $$.type = obj->type;
     }
    | IDENT '[' Expression ']' '[' Expression ']' { 
            Object *obj = findVariable($1);
            printf("IDENT (name=%s, address=%ld)\n", $1, obj->symbol->addr);
            $$.type = obj->type;
     }     
;

NumberExpression
    : INT_LIT   { printf("INT_LIT %d\n", $1); $$.type = OBJECT_TYPE_INT; }
    | FLOAT_LIT { printf("FLOAT_LIT %f\n", $1); $$.type = OBJECT_TYPE_FLOAT; }
;

BoolExpression
    : BOOL_LIT { printf("BOOL_LIT %s\n", $1 ? "TRUE" : "FALSE"); $$.type = OBJECT_TYPE_BOOL; }
;

%%
/* C code section */
