#ifndef MAIN_H
#define MAIN_H
#include "compiler_common.h"

#define code(format, ...) \
    fprintf(yyout, "%*s" format "\n", scopeLevel << 2, "", __VA_ARGS__)
#define codeRaw(code) \
    fprintf(yyout, "%*s" code "\n", scopeLevel << 2, "")

extern FILE* yyout;
extern FILE* yyin;
extern bool compileError;
extern int scopeLevel;
int yyparse();
int yylex();
int yylex_destroy();

void pushScope();
void dumpScope();

Object* findVariable(char* variableName);
void initVariable(ObjectType variableType);
Object* createVariable(ObjectType variableType, LinkedList* arraySubscripts, char* variableName, int value);

void functionLocalsBegin();
void functionParmPush(ObjectType variableType, LinkedList* arraySubscripts, char* variableName);
void functionBegin(ObjectType returnType, LinkedList* arraySubscripts, char* funcName);
bool functionEnd(ObjectType returnType);

void returnObject(char* variableName);
void doReturn();
bool checkMainReturn();
bool checkMain();
bool checkReturn();

void functionArgsBegin();
void functionArgPush(Object* obj);
void functionCall(char* funcName, Object* out);

void stdoutPrint(Object* obj);
void greaterlower(Object* obj, char* op);
void equalornot(char *op);

void typeload(char* variableName);
void typeStore(char* variableName);
void DeclStore(ObjectType type, Object* obj);
void opassignment(Object* obj, char* op );
void logicassignment(Object* obj, char* op );

void CastVariable(ObjectType origintype, ObjectType castType);

void ifcondition(int flag);
void elsecondition(int flag);
void loopwhilecondition(int flag);
void loopforcondition(int flag);
void breakLoop(int flag);

void storeArr(char* variableName);
void loadArr(char* variableName);
void createArr(ObjectType type, int flag);

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

#endif
