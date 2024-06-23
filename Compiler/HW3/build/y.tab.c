/* A Bison parser, made by GNU Bison 3.8.2.  */

/* Bison implementation for Yacc-like parsers in C

   Copyright (C) 1984, 1989-1990, 2000-2015, 2018-2021 Free Software Foundation,
   Inc.

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <https://www.gnu.org/licenses/>.  */

/* As a special exception, you may create a larger work that contains
   part or all of the Bison parser skeleton and distribute that work
   under terms of your choice, so long as that work isn't itself a
   parser generator using the skeleton or a modified version thereof
   as a parser skeleton.  Alternatively, if you modify or redistribute
   the parser skeleton itself, you may (at your option) remove this
   special exception, which will cause the skeleton and the resulting
   Bison output files to be licensed under the GNU General Public
   License without this special exception.

   This special exception was added by the Free Software Foundation in
   version 2.2 of Bison.  */

/* C LALR(1) parser skeleton written by Richard Stallman, by
   simplifying the original so-called "semantic" parser.  */

/* DO NOT RELY ON FEATURES THAT ARE NOT DOCUMENTED in the manual,
   especially those whose name start with YY_ or yy_.  They are
   private implementation details that can be changed or removed.  */

/* All symbols defined below should begin with yy or YY, to avoid
   infringing on user name space.  This should be done even for local
   variables, as they might otherwise be expanded by user macros.
   There are some unavoidable exceptions within include files to
   define necessary library symbols; they are noted "INFRINGES ON
   USER NAME SPACE" below.  */

/* Identify Bison output, and Bison version.  */
#define YYBISON 30802

/* Bison version string.  */
#define YYBISON_VERSION "3.8.2"

/* Skeleton name.  */
#define YYSKELETON_NAME "yacc.c"

/* Pure parsers.  */
#define YYPURE 0

/* Push parsers.  */
#define YYPUSH 0

/* Pull parsers.  */
#define YYPULL 1




/* First part of user prologue.  */
#line 2 "./compiler.y"

    #include "compiler_util.h"
    #include "main.h"

    int yydebug = 1;
    ObjectType tempType = OBJECT_TYPE_INT;
    char *tempName = NULL;
    char *tempFuncName = NULL;    
    int isArray = 0, isMain = 0, isReturn = 0;
    int breakwhichLoop = 0;
    int arrayNumber = 0;

#line 84 "./build/y.tab.c"

# ifndef YY_CAST
#  ifdef __cplusplus
#   define YY_CAST(Type, Val) static_cast<Type> (Val)
#   define YY_REINTERPRET_CAST(Type, Val) reinterpret_cast<Type> (Val)
#  else
#   define YY_CAST(Type, Val) ((Type) (Val))
#   define YY_REINTERPRET_CAST(Type, Val) ((Type) (Val))
#  endif
# endif
# ifndef YY_NULLPTR
#  if defined __cplusplus
#   if 201103L <= __cplusplus
#    define YY_NULLPTR nullptr
#   else
#    define YY_NULLPTR 0
#   endif
#  else
#   define YY_NULLPTR ((void*)0)
#  endif
# endif

#include "y.tab.h"
/* Symbol kind.  */
enum yysymbol_kind_t
{
  YYSYMBOL_YYEMPTY = -2,
  YYSYMBOL_YYEOF = 0,                      /* "end of file"  */
  YYSYMBOL_YYerror = 1,                    /* error  */
  YYSYMBOL_YYUNDEF = 2,                    /* "invalid token"  */
  YYSYMBOL_COUT = 3,                       /* COUT  */
  YYSYMBOL_SHR = 4,                        /* SHR  */
  YYSYMBOL_SHL = 5,                        /* SHL  */
  YYSYMBOL_BAN = 6,                        /* BAN  */
  YYSYMBOL_BOR = 7,                        /* BOR  */
  YYSYMBOL_BNT = 8,                        /* BNT  */
  YYSYMBOL_BXO = 9,                        /* BXO  */
  YYSYMBOL_ADD = 10,                       /* ADD  */
  YYSYMBOL_SUB = 11,                       /* SUB  */
  YYSYMBOL_MUL = 12,                       /* MUL  */
  YYSYMBOL_DIV = 13,                       /* DIV  */
  YYSYMBOL_REM = 14,                       /* REM  */
  YYSYMBOL_NOT = 15,                       /* NOT  */
  YYSYMBOL_GTR = 16,                       /* GTR  */
  YYSYMBOL_LES = 17,                       /* LES  */
  YYSYMBOL_GEQ = 18,                       /* GEQ  */
  YYSYMBOL_LEQ = 19,                       /* LEQ  */
  YYSYMBOL_EQL = 20,                       /* EQL  */
  YYSYMBOL_NEQ = 21,                       /* NEQ  */
  YYSYMBOL_LAN = 22,                       /* LAN  */
  YYSYMBOL_LOR = 23,                       /* LOR  */
  YYSYMBOL_VAL_ASSIGN = 24,                /* VAL_ASSIGN  */
  YYSYMBOL_ADD_ASSIGN = 25,                /* ADD_ASSIGN  */
  YYSYMBOL_SUB_ASSIGN = 26,                /* SUB_ASSIGN  */
  YYSYMBOL_MUL_ASSIGN = 27,                /* MUL_ASSIGN  */
  YYSYMBOL_DIV_ASSIGN = 28,                /* DIV_ASSIGN  */
  YYSYMBOL_REM_ASSIGN = 29,                /* REM_ASSIGN  */
  YYSYMBOL_BAN_ASSIGN = 30,                /* BAN_ASSIGN  */
  YYSYMBOL_BOR_ASSIGN = 31,                /* BOR_ASSIGN  */
  YYSYMBOL_BXO_ASSIGN = 32,                /* BXO_ASSIGN  */
  YYSYMBOL_SHR_ASSIGN = 33,                /* SHR_ASSIGN  */
  YYSYMBOL_SHL_ASSIGN = 34,                /* SHL_ASSIGN  */
  YYSYMBOL_INC_ASSIGN = 35,                /* INC_ASSIGN  */
  YYSYMBOL_DEC_ASSIGN = 36,                /* DEC_ASSIGN  */
  YYSYMBOL_IF = 37,                        /* IF  */
  YYSYMBOL_ELSE = 38,                      /* ELSE  */
  YYSYMBOL_FOR = 39,                       /* FOR  */
  YYSYMBOL_WHILE = 40,                     /* WHILE  */
  YYSYMBOL_RETURN = 41,                    /* RETURN  */
  YYSYMBOL_BREAK = 42,                     /* BREAK  */
  YYSYMBOL_CONTINUE = 43,                  /* CONTINUE  */
  YYSYMBOL_VARIABLE_T = 44,                /* VARIABLE_T  */
  YYSYMBOL_BOOL_LIT = 45,                  /* BOOL_LIT  */
  YYSYMBOL_CHAR_LIT = 46,                  /* CHAR_LIT  */
  YYSYMBOL_INT_LIT = 47,                   /* INT_LIT  */
  YYSYMBOL_FLOAT_LIT = 48,                 /* FLOAT_LIT  */
  YYSYMBOL_STR_LIT = 49,                   /* STR_LIT  */
  YYSYMBOL_IDENT = 50,                     /* IDENT  */
  YYSYMBOL_CALL = 51,                      /* CALL  */
  YYSYMBOL_THEN = 52,                      /* THEN  */
  YYSYMBOL_53_ = 53,                       /* ';'  */
  YYSYMBOL_54_ = 54,                       /* '('  */
  YYSYMBOL_55_ = 55,                       /* ')'  */
  YYSYMBOL_56_ = 56,                       /* '{'  */
  YYSYMBOL_57_ = 57,                       /* '}'  */
  YYSYMBOL_58_ = 58,                       /* ','  */
  YYSYMBOL_59_ = 59,                       /* '['  */
  YYSYMBOL_60_ = 60,                       /* ']'  */
  YYSYMBOL_61_ = 61,                       /* ':'  */
  YYSYMBOL_YYACCEPT = 62,                  /* $accept  */
  YYSYMBOL_Program = 63,                   /* Program  */
  YYSYMBOL_64_1 = 64,                      /* $@1  */
  YYSYMBOL_GlobalStmtList = 65,            /* GlobalStmtList  */
  YYSYMBOL_GlobalStmt = 66,                /* GlobalStmt  */
  YYSYMBOL_DefineVariableStmt = 67,        /* DefineVariableStmt  */
  YYSYMBOL_FunctionDefStmt = 68,           /* FunctionDefStmt  */
  YYSYMBOL_69_2 = 69,                      /* $@2  */
  YYSYMBOL_70_3 = 70,                      /* $@3  */
  YYSYMBOL_FunctionParameterStmtList = 71, /* FunctionParameterStmtList  */
  YYSYMBOL_FunctionParameterStmt = 72,     /* FunctionParameterStmt  */
  YYSYMBOL_StmtList = 73,                  /* StmtList  */
  YYSYMBOL_FunctionStmt = 74,              /* FunctionStmt  */
  YYSYMBOL_AssignmentStmt = 75,            /* AssignmentStmt  */
  YYSYMBOL_76_4 = 76,                      /* $@4  */
  YYSYMBOL_77_5 = 77,                      /* $@5  */
  YYSYMBOL_78_6 = 78,                      /* $@6  */
  YYSYMBOL_AssignmentOperator = 79,        /* AssignmentOperator  */
  YYSYMBOL_IfStmt = 80,                    /* IfStmt  */
  YYSYMBOL_81_7 = 81,                      /* $@7  */
  YYSYMBOL_82_8 = 82,                      /* $@8  */
  YYSYMBOL_83_9 = 83,                      /* $@9  */
  YYSYMBOL_84_10 = 84,                     /* $@10  */
  YYSYMBOL_85_11 = 85,                     /* $@11  */
  YYSYMBOL_86_12 = 86,                     /* $@12  */
  YYSYMBOL_87_13 = 87,                     /* $@13  */
  YYSYMBOL_ElseStmt = 88,                  /* ElseStmt  */
  YYSYMBOL_89_14 = 89,                     /* $@14  */
  YYSYMBOL_90_15 = 90,                     /* $@15  */
  YYSYMBOL_91_16 = 91,                     /* $@16  */
  YYSYMBOL_LoopStmt = 92,                  /* LoopStmt  */
  YYSYMBOL_WhileStmt = 93,                 /* WhileStmt  */
  YYSYMBOL_94_17 = 94,                     /* $@17  */
  YYSYMBOL_95_18 = 95,                     /* $@18  */
  YYSYMBOL_96_19 = 96,                     /* $@19  */
  YYSYMBOL_97_20 = 97,                     /* $@20  */
  YYSYMBOL_98_21 = 98,                     /* $@21  */
  YYSYMBOL_ForStmt = 99,                   /* ForStmt  */
  YYSYMBOL_100_22 = 100,                   /* $@22  */
  YYSYMBOL_101_23 = 101,                   /* $@23  */
  YYSYMBOL_102_24 = 102,                   /* $@24  */
  YYSYMBOL_103_25 = 103,                   /* $@25  */
  YYSYMBOL_104_26 = 104,                   /* $@26  */
  YYSYMBOL_ForDefine = 105,                /* ForDefine  */
  YYSYMBOL_InitDefine = 106,               /* InitDefine  */
  YYSYMBOL_IterativeCondition = 107,       /* IterativeCondition  */
  YYSYMBOL_108_27 = 108,                   /* $@27  */
  YYSYMBOL_IterativeUpdate = 109,          /* IterativeUpdate  */
  YYSYMBOL_110_28 = 110,                   /* $@28  */
  YYSYMBOL_DefineStmt = 111,               /* DefineStmt  */
  YYSYMBOL_112_29 = 112,                   /* $@29  */
  YYSYMBOL_DefineVariables = 113,          /* DefineVariables  */
  YYSYMBOL_Variable = 114,                 /* Variable  */
  YYSYMBOL_115_30 = 115,                   /* $@30  */
  YYSYMBOL_ArrayList = 116,                /* ArrayList  */
  YYSYMBOL_117_31 = 117,                   /* $@31  */
  YYSYMBOL_118_32 = 118,                   /* $@32  */
  YYSYMBOL_BodyStmt = 119,                 /* BodyStmt  */
  YYSYMBOL_CoutParmListStmt = 120,         /* CoutParmListStmt  */
  YYSYMBOL_121_33 = 121,                   /* $@33  */
  YYSYMBOL_122_34 = 122,                   /* $@34  */
  YYSYMBOL_ReturnCondition = 123,          /* ReturnCondition  */
  YYSYMBOL_124_35 = 124,                   /* $@35  */
  YYSYMBOL_125_36 = 125,                   /* $@36  */
  YYSYMBOL_Expression = 126,               /* Expression  */
  YYSYMBOL_LogicExpression = 127,          /* LogicExpression  */
  YYSYMBOL_OrExpression = 128,             /* OrExpression  */
  YYSYMBOL_AndExpression = 129,            /* AndExpression  */
  YYSYMBOL_BitOrExpression = 130,          /* BitOrExpression  */
  YYSYMBOL_BitXorExpression = 131,         /* BitXorExpression  */
  YYSYMBOL_BitAndExpression = 132,         /* BitAndExpression  */
  YYSYMBOL_EqualExpression = 133,          /* EqualExpression  */
  YYSYMBOL_CompareExpression = 134,        /* CompareExpression  */
  YYSYMBOL_ShiftExpression = 135,          /* ShiftExpression  */
  YYSYMBOL_AddOPExpression = 136,          /* AddOPExpression  */
  YYSYMBOL_MulOPExpression = 137,          /* MulOPExpression  */
  YYSYMBOL_CastExpression = 138,           /* CastExpression  */
  YYSYMBOL_UnsignNumberExpression = 139,   /* UnsignNumberExpression  */
  YYSYMBOL_LogicNotExpression = 140,       /* LogicNotExpression  */
  YYSYMBOL_PrimaryExpression = 141,        /* PrimaryExpression  */
  YYSYMBOL_CallFunction = 142,             /* CallFunction  */
  YYSYMBOL_FunctionList = 143,             /* FunctionList  */
  YYSYMBOL_IdentExpression = 144,          /* IdentExpression  */
  YYSYMBOL_ArrayExpression = 145,          /* ArrayExpression  */
  YYSYMBOL_146_37 = 146,                   /* $@37  */
  YYSYMBOL_147_38 = 147,                   /* $@38  */
  YYSYMBOL_ArrayIndices = 148,             /* ArrayIndices  */
  YYSYMBOL_149_39 = 149,                   /* $@39  */
  YYSYMBOL_NumberExpression = 150,         /* NumberExpression  */
  YYSYMBOL_BoolExpression = 151            /* BoolExpression  */
};
typedef enum yysymbol_kind_t yysymbol_kind_t;




#ifdef short
# undef short
#endif

/* On compilers that do not define __PTRDIFF_MAX__ etc., make sure
   <limits.h> and (if available) <stdint.h> are included
   so that the code can choose integer types of a good width.  */

#ifndef __PTRDIFF_MAX__
# include <limits.h> /* INFRINGES ON USER NAME SPACE */
# if defined __STDC_VERSION__ && 199901 <= __STDC_VERSION__
#  include <stdint.h> /* INFRINGES ON USER NAME SPACE */
#  define YY_STDINT_H
# endif
#endif

/* Narrow types that promote to a signed type and that can represent a
   signed or unsigned integer of at least N bits.  In tables they can
   save space and decrease cache pressure.  Promoting to a signed type
   helps avoid bugs in integer arithmetic.  */

#ifdef __INT_LEAST8_MAX__
typedef __INT_LEAST8_TYPE__ yytype_int8;
#elif defined YY_STDINT_H
typedef int_least8_t yytype_int8;
#else
typedef signed char yytype_int8;
#endif

#ifdef __INT_LEAST16_MAX__
typedef __INT_LEAST16_TYPE__ yytype_int16;
#elif defined YY_STDINT_H
typedef int_least16_t yytype_int16;
#else
typedef short yytype_int16;
#endif

/* Work around bug in HP-UX 11.23, which defines these macros
   incorrectly for preprocessor constants.  This workaround can likely
   be removed in 2023, as HPE has promised support for HP-UX 11.23
   (aka HP-UX 11i v2) only through the end of 2022; see Table 2 of
   <https://h20195.www2.hpe.com/V2/getpdf.aspx/4AA4-7673ENW.pdf>.  */
#ifdef __hpux
# undef UINT_LEAST8_MAX
# undef UINT_LEAST16_MAX
# define UINT_LEAST8_MAX 255
# define UINT_LEAST16_MAX 65535
#endif

#if defined __UINT_LEAST8_MAX__ && __UINT_LEAST8_MAX__ <= __INT_MAX__
typedef __UINT_LEAST8_TYPE__ yytype_uint8;
#elif (!defined __UINT_LEAST8_MAX__ && defined YY_STDINT_H \
       && UINT_LEAST8_MAX <= INT_MAX)
typedef uint_least8_t yytype_uint8;
#elif !defined __UINT_LEAST8_MAX__ && UCHAR_MAX <= INT_MAX
typedef unsigned char yytype_uint8;
#else
typedef short yytype_uint8;
#endif

#if defined __UINT_LEAST16_MAX__ && __UINT_LEAST16_MAX__ <= __INT_MAX__
typedef __UINT_LEAST16_TYPE__ yytype_uint16;
#elif (!defined __UINT_LEAST16_MAX__ && defined YY_STDINT_H \
       && UINT_LEAST16_MAX <= INT_MAX)
typedef uint_least16_t yytype_uint16;
#elif !defined __UINT_LEAST16_MAX__ && USHRT_MAX <= INT_MAX
typedef unsigned short yytype_uint16;
#else
typedef int yytype_uint16;
#endif

#ifndef YYPTRDIFF_T
# if defined __PTRDIFF_TYPE__ && defined __PTRDIFF_MAX__
#  define YYPTRDIFF_T __PTRDIFF_TYPE__
#  define YYPTRDIFF_MAXIMUM __PTRDIFF_MAX__
# elif defined PTRDIFF_MAX
#  ifndef ptrdiff_t
#   include <stddef.h> /* INFRINGES ON USER NAME SPACE */
#  endif
#  define YYPTRDIFF_T ptrdiff_t
#  define YYPTRDIFF_MAXIMUM PTRDIFF_MAX
# else
#  define YYPTRDIFF_T long
#  define YYPTRDIFF_MAXIMUM LONG_MAX
# endif
#endif

#ifndef YYSIZE_T
# ifdef __SIZE_TYPE__
#  define YYSIZE_T __SIZE_TYPE__
# elif defined size_t
#  define YYSIZE_T size_t
# elif defined __STDC_VERSION__ && 199901 <= __STDC_VERSION__
#  include <stddef.h> /* INFRINGES ON USER NAME SPACE */
#  define YYSIZE_T size_t
# else
#  define YYSIZE_T unsigned
# endif
#endif

#define YYSIZE_MAXIMUM                                  \
  YY_CAST (YYPTRDIFF_T,                                 \
           (YYPTRDIFF_MAXIMUM < YY_CAST (YYSIZE_T, -1)  \
            ? YYPTRDIFF_MAXIMUM                         \
            : YY_CAST (YYSIZE_T, -1)))

#define YYSIZEOF(X) YY_CAST (YYPTRDIFF_T, sizeof (X))


/* Stored state numbers (used for stacks). */
typedef yytype_int16 yy_state_t;

/* State numbers in computations.  */
typedef int yy_state_fast_t;

#ifndef YY_
# if defined YYENABLE_NLS && YYENABLE_NLS
#  if ENABLE_NLS
#   include <libintl.h> /* INFRINGES ON USER NAME SPACE */
#   define YY_(Msgid) dgettext ("bison-runtime", Msgid)
#  endif
# endif
# ifndef YY_
#  define YY_(Msgid) Msgid
# endif
#endif


#ifndef YY_ATTRIBUTE_PURE
# if defined __GNUC__ && 2 < __GNUC__ + (96 <= __GNUC_MINOR__)
#  define YY_ATTRIBUTE_PURE __attribute__ ((__pure__))
# else
#  define YY_ATTRIBUTE_PURE
# endif
#endif

#ifndef YY_ATTRIBUTE_UNUSED
# if defined __GNUC__ && 2 < __GNUC__ + (7 <= __GNUC_MINOR__)
#  define YY_ATTRIBUTE_UNUSED __attribute__ ((__unused__))
# else
#  define YY_ATTRIBUTE_UNUSED
# endif
#endif

/* Suppress unused-variable warnings by "using" E.  */
#if ! defined lint || defined __GNUC__
# define YY_USE(E) ((void) (E))
#else
# define YY_USE(E) /* empty */
#endif

/* Suppress an incorrect diagnostic about yylval being uninitialized.  */
#if defined __GNUC__ && ! defined __ICC && 406 <= __GNUC__ * 100 + __GNUC_MINOR__
# if __GNUC__ * 100 + __GNUC_MINOR__ < 407
#  define YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN                           \
    _Pragma ("GCC diagnostic push")                                     \
    _Pragma ("GCC diagnostic ignored \"-Wuninitialized\"")
# else
#  define YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN                           \
    _Pragma ("GCC diagnostic push")                                     \
    _Pragma ("GCC diagnostic ignored \"-Wuninitialized\"")              \
    _Pragma ("GCC diagnostic ignored \"-Wmaybe-uninitialized\"")
# endif
# define YY_IGNORE_MAYBE_UNINITIALIZED_END      \
    _Pragma ("GCC diagnostic pop")
#else
# define YY_INITIAL_VALUE(Value) Value
#endif
#ifndef YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN
# define YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN
# define YY_IGNORE_MAYBE_UNINITIALIZED_END
#endif
#ifndef YY_INITIAL_VALUE
# define YY_INITIAL_VALUE(Value) /* Nothing. */
#endif

#if defined __cplusplus && defined __GNUC__ && ! defined __ICC && 6 <= __GNUC__
# define YY_IGNORE_USELESS_CAST_BEGIN                          \
    _Pragma ("GCC diagnostic push")                            \
    _Pragma ("GCC diagnostic ignored \"-Wuseless-cast\"")
# define YY_IGNORE_USELESS_CAST_END            \
    _Pragma ("GCC diagnostic pop")
#endif
#ifndef YY_IGNORE_USELESS_CAST_BEGIN
# define YY_IGNORE_USELESS_CAST_BEGIN
# define YY_IGNORE_USELESS_CAST_END
#endif


#define YY_ASSERT(E) ((void) (0 && (E)))

#if !defined yyoverflow

/* The parser invokes alloca or malloc; define the necessary symbols.  */

# ifdef YYSTACK_USE_ALLOCA
#  if YYSTACK_USE_ALLOCA
#   ifdef __GNUC__
#    define YYSTACK_ALLOC __builtin_alloca
#   elif defined __BUILTIN_VA_ARG_INCR
#    include <alloca.h> /* INFRINGES ON USER NAME SPACE */
#   elif defined _AIX
#    define YYSTACK_ALLOC __alloca
#   elif defined _MSC_VER
#    include <malloc.h> /* INFRINGES ON USER NAME SPACE */
#    define alloca _alloca
#   else
#    define YYSTACK_ALLOC alloca
#    if ! defined _ALLOCA_H && ! defined EXIT_SUCCESS
#     include <stdlib.h> /* INFRINGES ON USER NAME SPACE */
      /* Use EXIT_SUCCESS as a witness for stdlib.h.  */
#     ifndef EXIT_SUCCESS
#      define EXIT_SUCCESS 0
#     endif
#    endif
#   endif
#  endif
# endif

# ifdef YYSTACK_ALLOC
   /* Pacify GCC's 'empty if-body' warning.  */
#  define YYSTACK_FREE(Ptr) do { /* empty */; } while (0)
#  ifndef YYSTACK_ALLOC_MAXIMUM
    /* The OS might guarantee only one guard page at the bottom of the stack,
       and a page size can be as small as 4096 bytes.  So we cannot safely
       invoke alloca (N) if N exceeds 4096.  Use a slightly smaller number
       to allow for a few compiler-allocated temporary stack slots.  */
#   define YYSTACK_ALLOC_MAXIMUM 4032 /* reasonable circa 2006 */
#  endif
# else
#  define YYSTACK_ALLOC YYMALLOC
#  define YYSTACK_FREE YYFREE
#  ifndef YYSTACK_ALLOC_MAXIMUM
#   define YYSTACK_ALLOC_MAXIMUM YYSIZE_MAXIMUM
#  endif
#  if (defined __cplusplus && ! defined EXIT_SUCCESS \
       && ! ((defined YYMALLOC || defined malloc) \
             && (defined YYFREE || defined free)))
#   include <stdlib.h> /* INFRINGES ON USER NAME SPACE */
#   ifndef EXIT_SUCCESS
#    define EXIT_SUCCESS 0
#   endif
#  endif
#  ifndef YYMALLOC
#   define YYMALLOC malloc
#   if ! defined malloc && ! defined EXIT_SUCCESS
void *malloc (YYSIZE_T); /* INFRINGES ON USER NAME SPACE */
#   endif
#  endif
#  ifndef YYFREE
#   define YYFREE free
#   if ! defined free && ! defined EXIT_SUCCESS
void free (void *); /* INFRINGES ON USER NAME SPACE */
#   endif
#  endif
# endif
#endif /* !defined yyoverflow */

#if (! defined yyoverflow \
     && (! defined __cplusplus \
         || (defined YYSTYPE_IS_TRIVIAL && YYSTYPE_IS_TRIVIAL)))

/* A type that is properly aligned for any stack member.  */
union yyalloc
{
  yy_state_t yyss_alloc;
  YYSTYPE yyvs_alloc;
};

/* The size of the maximum gap between one aligned stack and the next.  */
# define YYSTACK_GAP_MAXIMUM (YYSIZEOF (union yyalloc) - 1)

/* The size of an array large to enough to hold all stacks, each with
   N elements.  */
# define YYSTACK_BYTES(N) \
     ((N) * (YYSIZEOF (yy_state_t) + YYSIZEOF (YYSTYPE)) \
      + YYSTACK_GAP_MAXIMUM)

# define YYCOPY_NEEDED 1

/* Relocate STACK from its old location to the new one.  The
   local variables YYSIZE and YYSTACKSIZE give the old and new number of
   elements in the stack, and YYPTR gives the new location of the
   stack.  Advance YYPTR to a properly aligned location for the next
   stack.  */
# define YYSTACK_RELOCATE(Stack_alloc, Stack)                           \
    do                                                                  \
      {                                                                 \
        YYPTRDIFF_T yynewbytes;                                         \
        YYCOPY (&yyptr->Stack_alloc, Stack, yysize);                    \
        Stack = &yyptr->Stack_alloc;                                    \
        yynewbytes = yystacksize * YYSIZEOF (*Stack) + YYSTACK_GAP_MAXIMUM; \
        yyptr += yynewbytes / YYSIZEOF (*yyptr);                        \
      }                                                                 \
    while (0)

#endif

#if defined YYCOPY_NEEDED && YYCOPY_NEEDED
/* Copy COUNT objects from SRC to DST.  The source and destination do
   not overlap.  */
# ifndef YYCOPY
#  if defined __GNUC__ && 1 < __GNUC__
#   define YYCOPY(Dst, Src, Count) \
      __builtin_memcpy (Dst, Src, YY_CAST (YYSIZE_T, (Count)) * sizeof (*(Src)))
#  else
#   define YYCOPY(Dst, Src, Count)              \
      do                                        \
        {                                       \
          YYPTRDIFF_T yyi;                      \
          for (yyi = 0; yyi < (Count); yyi++)   \
            (Dst)[yyi] = (Src)[yyi];            \
        }                                       \
      while (0)
#  endif
# endif
#endif /* !YYCOPY_NEEDED */

/* YYFINAL -- State number of the termination state.  */
#define YYFINAL  3
/* YYLAST -- Last index in YYTABLE.  */
#define YYLAST   324

/* YYNTOKENS -- Number of terminals.  */
#define YYNTOKENS  62
/* YYNNTS -- Number of nonterminals.  */
#define YYNNTS  90
/* YYNRULES -- Number of rules.  */
#define YYNRULES  169
/* YYNSTATES -- Number of states.  */
#define YYNSTATES  270

/* YYMAXUTOK -- Last valid token kind.  */
#define YYMAXUTOK   307


/* YYTRANSLATE(TOKEN-NUM) -- Symbol number corresponding to TOKEN-NUM
   as returned by yylex, with out-of-bounds checking.  */
#define YYTRANSLATE(YYX)                                \
  (0 <= (YYX) && (YYX) <= YYMAXUTOK                     \
   ? YY_CAST (yysymbol_kind_t, yytranslate[YYX])        \
   : YYSYMBOL_YYUNDEF)

/* YYTRANSLATE[TOKEN-NUM] -- Symbol number corresponding to TOKEN-NUM
   as returned by yylex.  */
static const yytype_int8 yytranslate[] =
{
       0,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
      54,    55,     2,     2,    58,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,    61,    53,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,    59,     2,    60,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,    56,     2,    57,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     1,     2,     3,     4,
       5,     6,     7,     8,     9,    10,    11,    12,    13,    14,
      15,    16,    17,    18,    19,    20,    21,    22,    23,    24,
      25,    26,    27,    28,    29,    30,    31,    32,    33,    34,
      35,    36,    37,    38,    39,    40,    41,    42,    43,    44,
      45,    46,    47,    48,    49,    50,    51,    52
};

#if YYDEBUG
/* YYRLINE[YYN] -- Source line where rule number YYN was defined.  */
static const yytype_int16 yyrline[] =
{
       0,    90,    90,    90,    91,    95,    96,   100,   101,   105,
     110,   111,   110,   121,   122,   123,   126,   127,   132,   133,
     137,   138,   139,   140,   141,   142,   143,   148,   148,   155,
     155,   155,   162,   169,   176,   183,   190,   197,   198,   199,
     200,   201,   202,   203,   216,   233,   233,   233,   233,   233,
     234,   234,   234,   234,   238,   238,   238,   238,   239,   244,
     245,   249,   249,   249,   249,   249,   249,   253,   253,   253,
     253,   253,   253,   257,   258,   262,   263,   264,   268,   268,
     269,   273,   273,   274,   279,   279,   283,   284,   288,   289,
     296,   304,   303,   310,   320,   320,   321,   321,   322,   326,
     327,   328,   329,   333,   333,   334,   334,   338,   338,   339,
     339,   344,   348,   352,   358,   362,   368,   372,   378,   382,
     388,   392,   398,   402,   408,   414,   418,   424,   430,   436,
     442,   446,   452,   456,   463,   470,   474,   481,   488,   494,
     498,   503,   507,   514,   521,   525,   532,   538,   542,   543,
     544,   547,   550,   551,   552,   553,   557,   567,   568,   569,
     573,   591,   591,   591,   599,   599,   600,   605,   614,   620
};
#endif

/** Accessing symbol of state STATE.  */
#define YY_ACCESSING_SYMBOL(State) YY_CAST (yysymbol_kind_t, yystos[State])

#if YYDEBUG || 0
/* The user-facing name of the symbol whose (internal) number is
   YYSYMBOL.  No bounds checking.  */
static const char *yysymbol_name (yysymbol_kind_t yysymbol) YY_ATTRIBUTE_UNUSED;

/* YYTNAME[SYMBOL-NUM] -- String name of the symbol SYMBOL-NUM.
   First, the terminals, then, starting at YYNTOKENS, nonterminals.  */
static const char *const yytname[] =
{
  "\"end of file\"", "error", "\"invalid token\"", "COUT", "SHR", "SHL",
  "BAN", "BOR", "BNT", "BXO", "ADD", "SUB", "MUL", "DIV", "REM", "NOT",
  "GTR", "LES", "GEQ", "LEQ", "EQL", "NEQ", "LAN", "LOR", "VAL_ASSIGN",
  "ADD_ASSIGN", "SUB_ASSIGN", "MUL_ASSIGN", "DIV_ASSIGN", "REM_ASSIGN",
  "BAN_ASSIGN", "BOR_ASSIGN", "BXO_ASSIGN", "SHR_ASSIGN", "SHL_ASSIGN",
  "INC_ASSIGN", "DEC_ASSIGN", "IF", "ELSE", "FOR", "WHILE", "RETURN",
  "BREAK", "CONTINUE", "VARIABLE_T", "BOOL_LIT", "CHAR_LIT", "INT_LIT",
  "FLOAT_LIT", "STR_LIT", "IDENT", "CALL", "THEN", "';'", "'('", "')'",
  "'{'", "'}'", "','", "'['", "']'", "':'", "$accept", "Program", "$@1",
  "GlobalStmtList", "GlobalStmt", "DefineVariableStmt", "FunctionDefStmt",
  "$@2", "$@3", "FunctionParameterStmtList", "FunctionParameterStmt",
  "StmtList", "FunctionStmt", "AssignmentStmt", "$@4", "$@5", "$@6",
  "AssignmentOperator", "IfStmt", "$@7", "$@8", "$@9", "$@10", "$@11",
  "$@12", "$@13", "ElseStmt", "$@14", "$@15", "$@16", "LoopStmt",
  "WhileStmt", "$@17", "$@18", "$@19", "$@20", "$@21", "ForStmt", "$@22",
  "$@23", "$@24", "$@25", "$@26", "ForDefine", "InitDefine",
  "IterativeCondition", "$@27", "IterativeUpdate", "$@28", "DefineStmt",
  "$@29", "DefineVariables", "Variable", "$@30", "ArrayList", "$@31",
  "$@32", "BodyStmt", "CoutParmListStmt", "$@33", "$@34",
  "ReturnCondition", "$@35", "$@36", "Expression", "LogicExpression",
  "OrExpression", "AndExpression", "BitOrExpression", "BitXorExpression",
  "BitAndExpression", "EqualExpression", "CompareExpression",
  "ShiftExpression", "AddOPExpression", "MulOPExpression",
  "CastExpression", "UnsignNumberExpression", "LogicNotExpression",
  "PrimaryExpression", "CallFunction", "FunctionList", "IdentExpression",
  "ArrayExpression", "$@37", "$@38", "ArrayIndices", "$@39",
  "NumberExpression", "BoolExpression", YY_NULLPTR
};

static const char *
yysymbol_name (yysymbol_kind_t yysymbol)
{
  return yytname[yysymbol];
}
#endif

#define YYPACT_NINF (-200)

#define yypact_value_is_default(Yyn) \
  ((Yyn) == YYPACT_NINF)

#define YYTABLE_NINF (-162)

#define yytable_value_is_error(Yyn) \
  0

/* YYPACT[STATE-NUM] -- Index in YYTABLE of the portion describing
   STATE-NUM.  */
static const yytype_int16 yypact[] =
{
       9,    34,    19,  -200,    21,    19,  -200,  -200,  -200,    67,
    -200,   236,    28,   257,   257,   247,   247,  -200,  -200,  -200,
    -200,  -200,   -46,   225,    44,  -200,    82,    88,   104,   103,
     107,    58,    10,   111,    70,    25,  -200,  -200,  -200,  -200,
    -200,  -200,  -200,  -200,  -200,    72,   236,  -200,  -200,  -200,
    -200,   236,    59,    62,    64,  -200,   236,   236,   236,   236,
     236,   236,   236,   236,   236,   236,   236,   236,   236,   236,
     236,   236,   236,    73,   -25,  -200,  -200,   -23,   236,    61,
     247,  -200,    88,   104,   103,   107,    58,    10,    10,   111,
     111,   111,   111,    70,    25,    25,  -200,  -200,  -200,    63,
    -200,    72,  -200,   236,    65,  -200,  -200,  -200,    68,    71,
    -200,  -200,  -200,   236,  -200,   185,    75,   126,    78,  -200,
    -200,     4,    83,    85,  -200,   -43,  -200,    12,  -200,    86,
    -200,  -200,  -200,  -200,    90,  -200,  -200,  -200,  -200,  -200,
       5,   236,  -200,  -200,   236,  -200,  -200,  -200,    91,   288,
      59,  -200,  -200,  -200,  -200,   236,  -200,  -200,    92,  -200,
      94,    93,     1,    87,  -200,   236,   236,   236,   236,   236,
     236,   236,   236,   236,   236,   236,  -200,  -200,  -200,    61,
    -200,   236,    96,    97,   236,  -200,   236,    41,    91,  -200,
    -200,  -200,  -200,  -200,  -200,  -200,  -200,  -200,  -200,  -200,
     288,  -200,  -200,  -200,   -38,   110,  -200,   106,  -200,  -200,
     112,   185,   113,  -200,   114,   118,    89,  -200,     7,   185,
    -200,  -200,   121,   236,  -200,  -200,    41,    33,   146,   129,
     124,   236,  -200,   130,   131,   133,  -200,  -200,  -200,   185,
     135,  -200,   185,    36,  -200,  -200,  -200,   185,  -200,   141,
     139,    38,   236,   146,   138,   140,  -200,  -200,  -200,  -200,
    -200,  -200,   185,  -200,  -200,   236,   164,  -200,  -200,  -200
};

/* YYDEFACT[STATE-NUM] -- Default reduction number in state STATE-NUM.
   Performed when YYTABLE does not specify something else to do.  Zero
   means the default is an error.  */
static const yytype_uint8 yydefact[] =
{
       2,     0,     0,     1,     0,     3,     6,     7,     8,    10,
       5,     0,     0,     0,     0,     0,     0,   169,   150,   167,
     168,   151,   160,     0,     0,   111,   112,   114,   116,   118,
     120,   122,   125,   130,   132,   135,   139,   141,   144,   147,
     149,   152,   155,   154,   153,    15,     0,   146,   145,   142,
     143,   159,     0,     0,     0,     9,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,    14,   158,     0,     0,   162,
       0,   148,   113,   115,   117,   119,   121,   124,   123,   126,
     127,   128,   129,   131,   133,   134,   136,   137,   138,    16,
      11,     0,   156,     0,     0,   164,   163,   140,     0,     0,
      13,   157,   166,     0,    17,     0,     0,     0,     0,    67,
      61,   107,     0,     0,    84,    27,    20,     0,    19,     0,
      24,    25,    59,    60,     0,    21,   100,    26,   165,   105,
       0,     0,    68,    62,     0,   110,   101,   102,     0,     0,
       0,    12,    18,    22,    23,     0,   103,    99,     0,    69,
       0,     0,    88,    85,    87,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,    43,    44,    28,    30,
     106,     0,    50,     0,     0,   108,     0,     0,     0,    32,
      33,    34,    35,    36,    37,    40,    41,    42,    38,    39,
       0,   104,    46,    51,    77,     0,    89,     0,    86,    31,
       0,     0,    27,    76,     0,     0,    75,    63,    90,     0,
      52,    70,    78,     0,    64,    91,     0,     0,    58,     0,
       0,     0,    74,     0,     0,     0,    47,    54,    53,     0,
      81,    79,     0,    96,    93,    48,    55,    71,    73,     0,
       0,     0,     0,    58,     0,     0,    82,    65,    92,    94,
      97,    49,     0,    72,    66,     0,     0,    95,    56,    57
};

/* YYPGOTO[NTERM-NUM].  */
static const yytype_int16 yypgoto[] =
{
    -200,  -200,  -200,  -200,   190,  -200,  -200,  -200,  -200,  -200,
      98,  -155,  -126,  -199,  -200,  -200,  -200,    -2,  -200,  -200,
    -200,  -200,  -200,  -200,  -200,  -200,   -51,  -200,  -200,  -200,
    -200,  -200,  -200,  -200,  -200,  -200,  -200,  -200,  -200,  -200,
    -200,  -200,  -200,  -200,  -200,  -200,  -200,  -200,  -200,    -4,
    -200,  -200,    22,  -200,  -200,  -200,  -200,  -200,  -200,  -200,
    -200,  -200,  -200,  -200,   -11,  -200,  -200,   153,   154,   155,
     156,   158,    42,   -42,   149,    31,   -53,   -12,    95,  -200,
    -113,  -200,  -200,  -200,  -200,  -200,    69,  -200,  -167,  -200
};

/* YYDEFGOTO[NTERM-NUM].  */
static const yytype_int16 yydefgoto[] =
{
       0,     1,     2,     5,     6,     7,     8,    12,   109,    74,
      75,   127,   128,   129,   149,   150,   200,   178,   130,   202,
     210,   245,   253,   203,   211,   228,   238,   246,   254,   269,
     131,   132,   143,   160,   224,   233,   264,   133,   142,   159,
     183,   229,   255,   214,   215,   230,   231,   248,   249,   134,
     148,   163,   164,   234,   251,   265,   252,   135,   140,   181,
     155,   136,   144,   145,    54,    25,    26,    27,    28,    29,
      30,    31,    32,    33,    34,    35,    36,    37,    38,    39,
      40,    77,    41,    42,    52,   106,    79,   113,    43,    44
};

/* YYTABLE[YYPACT[STATE-NUM]] -- What to do in state STATE-NUM.  If
   positive, shift that token.  If negative, reduce the rule whose
   number is the opposite.  If YYTABLE_NINF, syntax error.  */
static const yytype_int16 yytable[] =
{
      24,   152,   137,    49,    50,   213,   124,  -109,    51,    -4,
     156,    51,   212,  -161,   137,   117,   -29,    96,    97,    98,
     207,    89,    90,    91,    92,   186,    63,    64,    65,    66,
     100,   225,   102,   101,     3,   103,   117,    70,    71,    72,
      76,  -109,  -109,  -109,  -109,  -109,  -109,  -109,  -109,   118,
     256,   119,   120,   121,   122,   123,   124,  -109,   157,   235,
     187,  -109,   125,     4,   227,   126,   226,   104,   107,   151,
     118,     9,   119,   120,   121,   122,   123,   124,    61,    62,
      68,    69,    45,   125,   247,   220,   126,   250,    19,    20,
     236,    11,   111,   -98,   -98,   258,   259,    55,   137,    94,
      95,   152,   116,    87,    88,    56,   137,   266,    47,    48,
      57,    58,    59,    60,   137,    67,    73,    80,    78,    81,
     105,   152,   108,    99,   152,   112,   137,   115,   114,   137,
     158,   139,   141,   161,   137,   138,   146,   137,   147,   153,
     152,   162,   117,   154,   180,   188,   185,   182,   184,   137,
     223,   204,   -45,   137,   189,   190,   191,   192,   193,   194,
     195,   196,   197,   198,   199,   217,   218,   117,   219,   221,
     201,   222,   -29,   205,   -80,   206,   118,   240,   119,   120,
     121,   122,   123,   124,   237,   239,   242,   243,   117,   125,
     -83,   212,   126,   244,   262,    10,   257,   263,   209,   110,
     216,   118,   261,   119,   120,   121,   122,   123,   124,    82,
     208,    83,   232,    84,   125,    85,    93,   126,    86,   179,
     241,   268,   118,     0,   119,   120,   121,   122,   123,   124,
       0,    13,     0,    14,     0,   125,    15,     0,   126,     0,
      16,   260,    13,     0,    14,     0,     0,    15,     0,     0,
       0,    16,     0,    13,   267,    14,     0,     0,    15,     0,
       0,     0,    16,    13,     0,    14,     0,     0,     0,    53,
      17,    18,    19,    20,    21,    22,     0,     0,     0,    23,
       0,    17,    18,    19,    20,    21,    22,     0,     0,     0,
      23,     0,    17,    18,    19,    20,    21,    22,     0,     0,
       0,    46,    17,    18,    19,    20,    21,    22,     0,     0,
       0,    46,   165,   166,   167,   168,   169,   170,   171,   172,
     173,   174,   175,   176,   177
};

static const yytype_int16 yycheck[] =
{
      11,   127,   115,    15,    16,   204,    44,     3,    54,     0,
       5,    54,    50,    59,   127,     3,    59,    70,    71,    72,
     187,    63,    64,    65,    66,    24,    16,    17,    18,    19,
      55,    24,    55,    58,     0,    58,     3,    12,    13,    14,
      51,    37,    38,    39,    40,    41,    42,    43,    44,    37,
     249,    39,    40,    41,    42,    43,    44,    53,    53,   226,
      59,    57,    50,    44,   219,    53,    59,    78,    80,    57,
      37,    50,    39,    40,    41,    42,    43,    44,    20,    21,
      10,    11,    54,    50,   239,   211,    53,   242,    47,    48,
      57,    24,   103,    57,    58,    57,    58,    53,   211,    68,
      69,   227,   113,    61,    62,    23,   219,   262,    13,    14,
      22,     7,     9,     6,   227,     4,    44,    55,    59,    55,
      59,   247,    59,    50,   250,    60,   239,    56,    60,   242,
     141,     5,    54,   144,   247,    60,    53,   250,    53,    53,
     266,    50,     3,    53,   155,    58,    53,    55,    54,   262,
      61,    54,    56,   266,   165,   166,   167,   168,   169,   170,
     171,   172,   173,   174,   175,    55,    60,     3,    56,    55,
     181,    53,    59,   184,    53,   186,    37,    53,    39,    40,
      41,    42,    43,    44,    38,    56,    56,    56,     3,    50,
      55,    50,    53,    60,    56,     5,    57,    57,   200,   101,
     204,    37,   253,    39,    40,    41,    42,    43,    44,    56,
     188,    57,   223,    58,    50,    59,    67,    53,    60,   150,
     231,    57,    37,    -1,    39,    40,    41,    42,    43,    44,
      -1,     6,    -1,     8,    -1,    50,    11,    -1,    53,    -1,
      15,   252,     6,    -1,     8,    -1,    -1,    11,    -1,    -1,
      -1,    15,    -1,     6,   265,     8,    -1,    -1,    11,    -1,
      -1,    -1,    15,     6,    -1,     8,    -1,    -1,    -1,    44,
      45,    46,    47,    48,    49,    50,    -1,    -1,    -1,    54,
      -1,    45,    46,    47,    48,    49,    50,    -1,    -1,    -1,
      54,    -1,    45,    46,    47,    48,    49,    50,    -1,    -1,
      -1,    54,    45,    46,    47,    48,    49,    50,    -1,    -1,
      -1,    54,    24,    25,    26,    27,    28,    29,    30,    31,
      32,    33,    34,    35,    36
};

/* YYSTOS[STATE-NUM] -- The symbol kind of the accessing symbol of
   state STATE-NUM.  */
static const yytype_uint8 yystos[] =
{
       0,    63,    64,     0,    44,    65,    66,    67,    68,    50,
      66,    24,    69,     6,     8,    11,    15,    45,    46,    47,
      48,    49,    50,    54,   126,   127,   128,   129,   130,   131,
     132,   133,   134,   135,   136,   137,   138,   139,   140,   141,
     142,   144,   145,   150,   151,    54,    54,   140,   140,   139,
     139,    54,   146,    44,   126,    53,    23,    22,     7,     9,
       6,    20,    21,    16,    17,    18,    19,     4,    10,    11,
      12,    13,    14,    44,    71,    72,   126,   143,    59,   148,
      55,    55,   129,   130,   131,   132,   133,   134,   134,   135,
     135,   135,   135,   136,   137,   137,   138,   138,   138,    50,
      55,    58,    55,    58,   126,    59,   147,   139,    59,    70,
      72,   126,    60,   149,    60,    56,   126,     3,    37,    39,
      40,    41,    42,    43,    44,    50,    53,    73,    74,    75,
      80,    92,    93,    99,   111,   119,   123,   142,    60,     5,
     120,    54,   100,    94,   124,   125,    53,    53,   112,    76,
      77,    57,    74,    53,    53,   122,     5,    53,   126,   101,
      95,   126,    50,   113,   114,    24,    25,    26,    27,    28,
      29,    30,    31,    32,    33,    34,    35,    36,    79,   148,
     126,   121,    55,   102,    54,    53,    24,    59,    58,   126,
     126,   126,   126,   126,   126,   126,   126,   126,   126,   126,
      78,   126,    81,    85,    54,   126,   126,   150,   114,    79,
      82,    86,    50,    75,   105,   106,   111,    55,    60,    56,
      74,    55,    53,    61,    96,    24,    59,    73,    87,   103,
     107,   108,   126,    97,   115,   150,    57,    38,    88,    56,
      53,   126,    56,    56,    60,    83,    89,    73,   109,   110,
      73,   116,   118,    84,    90,   104,    75,    57,    57,    58,
     126,    88,    56,    57,    98,   117,    73,   126,    57,    91
};

/* YYR1[RULE-NUM] -- Symbol kind of the left-hand side of rule RULE-NUM.  */
static const yytype_uint8 yyr1[] =
{
       0,    62,    64,    63,    63,    65,    65,    66,    66,    67,
      69,    70,    68,    71,    71,    71,    72,    72,    73,    73,
      74,    74,    74,    74,    74,    74,    74,    76,    75,    77,
      78,    75,    79,    79,    79,    79,    79,    79,    79,    79,
      79,    79,    79,    79,    79,    81,    82,    83,    84,    80,
      85,    86,    87,    80,    89,    90,    91,    88,    88,    92,
      92,    94,    95,    96,    97,    98,    93,   100,   101,   102,
     103,   104,    99,   105,   105,   106,   106,   106,   108,   107,
     107,   110,   109,   109,   112,   111,   113,   113,   114,   114,
     114,   115,   114,   114,   117,   116,   118,   116,   116,   119,
     119,   119,   119,   121,   120,   122,   120,   124,   123,   125,
     123,   126,   127,   128,   128,   129,   129,   130,   130,   131,
     131,   132,   132,   133,   133,   133,   134,   134,   134,   134,
     134,   135,   135,   136,   136,   136,   137,   137,   137,   137,
     138,   138,   139,   139,   139,   140,   140,   140,   141,   141,
     141,   141,   141,   141,   141,   141,   142,   143,   143,   143,
     144,   146,   147,   145,   149,   148,   148,   150,   150,   151
};

/* YYR2[RULE-NUM] -- Number of symbols on the right-hand side of rule RULE-NUM.  */
static const yytype_int8 yyr2[] =
{
       0,     2,     0,     2,     0,     2,     1,     1,     1,     5,
       0,     0,    10,     3,     1,     0,     2,     4,     2,     1,
       1,     1,     2,     2,     1,     1,     1,     0,     3,     0,
       0,     5,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     1,     1,     0,     0,     0,     0,    12,
       0,     0,     0,     9,     0,     0,     0,     7,     0,     1,
       1,     0,     0,     0,     0,     0,    12,     0,     0,     0,
       0,     0,    12,     5,     3,     1,     1,     0,     0,     2,
       0,     0,     2,     0,     0,     3,     3,     1,     1,     3,
       4,     0,     9,     7,     0,     4,     0,     2,     0,     3,
       1,     2,     2,     0,     4,     0,     3,     0,     4,     0,
       2,     1,     1,     3,     1,     3,     1,     3,     1,     3,
       1,     3,     1,     3,     3,     1,     3,     3,     3,     3,
       1,     3,     1,     3,     3,     1,     3,     3,     3,     1,
       4,     1,     2,     2,     1,     2,     2,     1,     3,     1,
       1,     1,     1,     1,     1,     1,     4,     3,     1,     0,
       1,     0,     0,     4,     0,     5,     3,     1,     1,     1
};


enum { YYENOMEM = -2 };

#define yyerrok         (yyerrstatus = 0)
#define yyclearin       (yychar = YYEMPTY)

#define YYACCEPT        goto yyacceptlab
#define YYABORT         goto yyabortlab
#define YYERROR         goto yyerrorlab
#define YYNOMEM         goto yyexhaustedlab


#define YYRECOVERING()  (!!yyerrstatus)

#define YYBACKUP(Token, Value)                                    \
  do                                                              \
    if (yychar == YYEMPTY)                                        \
      {                                                           \
        yychar = (Token);                                         \
        yylval = (Value);                                         \
        YYPOPSTACK (yylen);                                       \
        yystate = *yyssp;                                         \
        goto yybackup;                                            \
      }                                                           \
    else                                                          \
      {                                                           \
        yyerror (YY_("syntax error: cannot back up")); \
        YYERROR;                                                  \
      }                                                           \
  while (0)

/* Backward compatibility with an undocumented macro.
   Use YYerror or YYUNDEF. */
#define YYERRCODE YYUNDEF


/* Enable debugging if requested.  */
#if YYDEBUG

# ifndef YYFPRINTF
#  include <stdio.h> /* INFRINGES ON USER NAME SPACE */
#  define YYFPRINTF fprintf
# endif

# define YYDPRINTF(Args)                        \
do {                                            \
  if (yydebug)                                  \
    YYFPRINTF Args;                             \
} while (0)




# define YY_SYMBOL_PRINT(Title, Kind, Value, Location)                    \
do {                                                                      \
  if (yydebug)                                                            \
    {                                                                     \
      YYFPRINTF (stderr, "%s ", Title);                                   \
      yy_symbol_print (stderr,                                            \
                  Kind, Value); \
      YYFPRINTF (stderr, "\n");                                           \
    }                                                                     \
} while (0)


/*-----------------------------------.
| Print this symbol's value on YYO.  |
`-----------------------------------*/

static void
yy_symbol_value_print (FILE *yyo,
                       yysymbol_kind_t yykind, YYSTYPE const * const yyvaluep)
{
  FILE *yyoutput = yyo;
  YY_USE (yyoutput);
  if (!yyvaluep)
    return;
  YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN
  YY_USE (yykind);
  YY_IGNORE_MAYBE_UNINITIALIZED_END
}


/*---------------------------.
| Print this symbol on YYO.  |
`---------------------------*/

static void
yy_symbol_print (FILE *yyo,
                 yysymbol_kind_t yykind, YYSTYPE const * const yyvaluep)
{
  YYFPRINTF (yyo, "%s %s (",
             yykind < YYNTOKENS ? "token" : "nterm", yysymbol_name (yykind));

  yy_symbol_value_print (yyo, yykind, yyvaluep);
  YYFPRINTF (yyo, ")");
}

/*------------------------------------------------------------------.
| yy_stack_print -- Print the state stack from its BOTTOM up to its |
| TOP (included).                                                   |
`------------------------------------------------------------------*/

static void
yy_stack_print (yy_state_t *yybottom, yy_state_t *yytop)
{
  YYFPRINTF (stderr, "Stack now");
  for (; yybottom <= yytop; yybottom++)
    {
      int yybot = *yybottom;
      YYFPRINTF (stderr, " %d", yybot);
    }
  YYFPRINTF (stderr, "\n");
}

# define YY_STACK_PRINT(Bottom, Top)                            \
do {                                                            \
  if (yydebug)                                                  \
    yy_stack_print ((Bottom), (Top));                           \
} while (0)


/*------------------------------------------------.
| Report that the YYRULE is going to be reduced.  |
`------------------------------------------------*/

static void
yy_reduce_print (yy_state_t *yyssp, YYSTYPE *yyvsp,
                 int yyrule)
{
  int yylno = yyrline[yyrule];
  int yynrhs = yyr2[yyrule];
  int yyi;
  YYFPRINTF (stderr, "Reducing stack by rule %d (line %d):\n",
             yyrule - 1, yylno);
  /* The symbols being reduced.  */
  for (yyi = 0; yyi < yynrhs; yyi++)
    {
      YYFPRINTF (stderr, "   $%d = ", yyi + 1);
      yy_symbol_print (stderr,
                       YY_ACCESSING_SYMBOL (+yyssp[yyi + 1 - yynrhs]),
                       &yyvsp[(yyi + 1) - (yynrhs)]);
      YYFPRINTF (stderr, "\n");
    }
}

# define YY_REDUCE_PRINT(Rule)          \
do {                                    \
  if (yydebug)                          \
    yy_reduce_print (yyssp, yyvsp, Rule); \
} while (0)

/* Nonzero means print parse trace.  It is left uninitialized so that
   multiple parsers can coexist.  */
int yydebug;
#else /* !YYDEBUG */
# define YYDPRINTF(Args) ((void) 0)
# define YY_SYMBOL_PRINT(Title, Kind, Value, Location)
# define YY_STACK_PRINT(Bottom, Top)
# define YY_REDUCE_PRINT(Rule)
#endif /* !YYDEBUG */


/* YYINITDEPTH -- initial size of the parser's stacks.  */
#ifndef YYINITDEPTH
# define YYINITDEPTH 200
#endif

/* YYMAXDEPTH -- maximum size the stacks can grow to (effective only
   if the built-in stack extension method is used).

   Do not make this value too large; the results are undefined if
   YYSTACK_ALLOC_MAXIMUM < YYSTACK_BYTES (YYMAXDEPTH)
   evaluated with infinite-precision integer arithmetic.  */

#ifndef YYMAXDEPTH
# define YYMAXDEPTH 10000
#endif






/*-----------------------------------------------.
| Release the memory associated to this symbol.  |
`-----------------------------------------------*/

static void
yydestruct (const char *yymsg,
            yysymbol_kind_t yykind, YYSTYPE *yyvaluep)
{
  YY_USE (yyvaluep);
  if (!yymsg)
    yymsg = "Deleting";
  YY_SYMBOL_PRINT (yymsg, yykind, yyvaluep, yylocationp);

  YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN
  YY_USE (yykind);
  YY_IGNORE_MAYBE_UNINITIALIZED_END
}


/* Lookahead token kind.  */
int yychar;

/* The semantic value of the lookahead symbol.  */
YYSTYPE yylval;
/* Number of syntax errors so far.  */
int yynerrs;




/*----------.
| yyparse.  |
`----------*/

int
yyparse (void)
{
    yy_state_fast_t yystate = 0;
    /* Number of tokens to shift before error messages enabled.  */
    int yyerrstatus = 0;

    /* Refer to the stacks through separate pointers, to allow yyoverflow
       to reallocate them elsewhere.  */

    /* Their size.  */
    YYPTRDIFF_T yystacksize = YYINITDEPTH;

    /* The state stack: array, bottom, top.  */
    yy_state_t yyssa[YYINITDEPTH];
    yy_state_t *yyss = yyssa;
    yy_state_t *yyssp = yyss;

    /* The semantic value stack: array, bottom, top.  */
    YYSTYPE yyvsa[YYINITDEPTH];
    YYSTYPE *yyvs = yyvsa;
    YYSTYPE *yyvsp = yyvs;

  int yyn;
  /* The return value of yyparse.  */
  int yyresult;
  /* Lookahead symbol kind.  */
  yysymbol_kind_t yytoken = YYSYMBOL_YYEMPTY;
  /* The variables used to return semantic value and location from the
     action routines.  */
  YYSTYPE yyval;



#define YYPOPSTACK(N)   (yyvsp -= (N), yyssp -= (N))

  /* The number of symbols on the RHS of the reduced rule.
     Keep to zero when no symbol should be popped.  */
  int yylen = 0;

  YYDPRINTF ((stderr, "Starting parse\n"));

  yychar = YYEMPTY; /* Cause a token to be read.  */

  goto yysetstate;


/*------------------------------------------------------------.
| yynewstate -- push a new state, which is found in yystate.  |
`------------------------------------------------------------*/
yynewstate:
  /* In all cases, when you get here, the value and location stacks
     have just been pushed.  So pushing a state here evens the stacks.  */
  yyssp++;


/*--------------------------------------------------------------------.
| yysetstate -- set current state (the top of the stack) to yystate.  |
`--------------------------------------------------------------------*/
yysetstate:
  YYDPRINTF ((stderr, "Entering state %d\n", yystate));
  YY_ASSERT (0 <= yystate && yystate < YYNSTATES);
  YY_IGNORE_USELESS_CAST_BEGIN
  *yyssp = YY_CAST (yy_state_t, yystate);
  YY_IGNORE_USELESS_CAST_END
  YY_STACK_PRINT (yyss, yyssp);

  if (yyss + yystacksize - 1 <= yyssp)
#if !defined yyoverflow && !defined YYSTACK_RELOCATE
    YYNOMEM;
#else
    {
      /* Get the current used size of the three stacks, in elements.  */
      YYPTRDIFF_T yysize = yyssp - yyss + 1;

# if defined yyoverflow
      {
        /* Give user a chance to reallocate the stack.  Use copies of
           these so that the &'s don't force the real ones into
           memory.  */
        yy_state_t *yyss1 = yyss;
        YYSTYPE *yyvs1 = yyvs;

        /* Each stack pointer address is followed by the size of the
           data in use in that stack, in bytes.  This used to be a
           conditional around just the two extra args, but that might
           be undefined if yyoverflow is a macro.  */
        yyoverflow (YY_("memory exhausted"),
                    &yyss1, yysize * YYSIZEOF (*yyssp),
                    &yyvs1, yysize * YYSIZEOF (*yyvsp),
                    &yystacksize);
        yyss = yyss1;
        yyvs = yyvs1;
      }
# else /* defined YYSTACK_RELOCATE */
      /* Extend the stack our own way.  */
      if (YYMAXDEPTH <= yystacksize)
        YYNOMEM;
      yystacksize *= 2;
      if (YYMAXDEPTH < yystacksize)
        yystacksize = YYMAXDEPTH;

      {
        yy_state_t *yyss1 = yyss;
        union yyalloc *yyptr =
          YY_CAST (union yyalloc *,
                   YYSTACK_ALLOC (YY_CAST (YYSIZE_T, YYSTACK_BYTES (yystacksize))));
        if (! yyptr)
          YYNOMEM;
        YYSTACK_RELOCATE (yyss_alloc, yyss);
        YYSTACK_RELOCATE (yyvs_alloc, yyvs);
#  undef YYSTACK_RELOCATE
        if (yyss1 != yyssa)
          YYSTACK_FREE (yyss1);
      }
# endif

      yyssp = yyss + yysize - 1;
      yyvsp = yyvs + yysize - 1;

      YY_IGNORE_USELESS_CAST_BEGIN
      YYDPRINTF ((stderr, "Stack size increased to %ld\n",
                  YY_CAST (long, yystacksize)));
      YY_IGNORE_USELESS_CAST_END

      if (yyss + yystacksize - 1 <= yyssp)
        YYABORT;
    }
#endif /* !defined yyoverflow && !defined YYSTACK_RELOCATE */


  if (yystate == YYFINAL)
    YYACCEPT;

  goto yybackup;


/*-----------.
| yybackup.  |
`-----------*/
yybackup:
  /* Do appropriate processing given the current state.  Read a
     lookahead token if we need one and don't already have one.  */

  /* First try to decide what to do without reference to lookahead token.  */
  yyn = yypact[yystate];
  if (yypact_value_is_default (yyn))
    goto yydefault;

  /* Not known => get a lookahead token if don't already have one.  */

  /* YYCHAR is either empty, or end-of-input, or a valid lookahead.  */
  if (yychar == YYEMPTY)
    {
      YYDPRINTF ((stderr, "Reading a token\n"));
      yychar = yylex ();
    }

  if (yychar <= YYEOF)
    {
      yychar = YYEOF;
      yytoken = YYSYMBOL_YYEOF;
      YYDPRINTF ((stderr, "Now at end of input.\n"));
    }
  else if (yychar == YYerror)
    {
      /* The scanner already issued an error message, process directly
         to error recovery.  But do not keep the error token as
         lookahead, it is too special and may lead us to an endless
         loop in error recovery. */
      yychar = YYUNDEF;
      yytoken = YYSYMBOL_YYerror;
      goto yyerrlab1;
    }
  else
    {
      yytoken = YYTRANSLATE (yychar);
      YY_SYMBOL_PRINT ("Next token is", yytoken, &yylval, &yylloc);
    }

  /* If the proper action on seeing token YYTOKEN is to reduce or to
     detect an error, take that action.  */
  yyn += yytoken;
  if (yyn < 0 || YYLAST < yyn || yycheck[yyn] != yytoken)
    goto yydefault;
  yyn = yytable[yyn];
  if (yyn <= 0)
    {
      if (yytable_value_is_error (yyn))
        goto yyerrlab;
      yyn = -yyn;
      goto yyreduce;
    }

  /* Count tokens shifted since error; after three, turn off error
     status.  */
  if (yyerrstatus)
    yyerrstatus--;

  /* Shift the lookahead token.  */
  YY_SYMBOL_PRINT ("Shifting", yytoken, &yylval, &yylloc);
  yystate = yyn;
  YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN
  *++yyvsp = yylval;
  YY_IGNORE_MAYBE_UNINITIALIZED_END

  /* Discard the shifted token.  */
  yychar = YYEMPTY;
  goto yynewstate;


/*-----------------------------------------------------------.
| yydefault -- do the default action for the current state.  |
`-----------------------------------------------------------*/
yydefault:
  yyn = yydefact[yystate];
  if (yyn == 0)
    goto yyerrlab;
  goto yyreduce;


/*-----------------------------.
| yyreduce -- do a reduction.  |
`-----------------------------*/
yyreduce:
  /* yyn is the number of a rule to reduce with.  */
  yylen = yyr2[yyn];

  /* If YYLEN is nonzero, implement the default value of the action:
     '$$ = $1'.

     Otherwise, the following line sets YYVAL to garbage.
     This behavior is undocumented and Bison
     users should not rely upon it.  Assigning to YYVAL
     unconditionally makes the parser a bit smaller, and it avoids a
     GCC warning that YYVAL may be used uninitialized.  */
  yyval = yyvsp[1-yylen];


  YY_REDUCE_PRINT (yyn);
  switch (yyn)
    {
  case 2: /* $@1: %empty  */
#line 90 "./compiler.y"
      { pushScope(); }
#line 1444 "./build/y.tab.c"
    break;

  case 3: /* Program: $@1 GlobalStmtList  */
#line 90 "./compiler.y"
                                      { dumpScope(); }
#line 1450 "./build/y.tab.c"
    break;

  case 10: /* $@2: %empty  */
#line 110 "./compiler.y"
                       { functionBegin((yyvsp[-1].var_type), NULL, (yyvsp[0].s_var)); tempFuncName = (yyvsp[0].s_var); isReturn = 0; isMain = 0; }
#line 1456 "./build/y.tab.c"
    break;

  case 11: /* $@3: %empty  */
#line 111 "./compiler.y"
    { functionLocalsBegin(); }
#line 1462 "./build/y.tab.c"
    break;

  case 12: /* FunctionDefStmt: VARIABLE_T IDENT $@2 '(' FunctionParameterStmtList ')' $@3 '{' StmtList '}'  */
#line 112 "./compiler.y"
    {   
        if(!strcmp(tempFuncName, "main")) isMain = 1;
        if(isMain && !isReturn) codeRaw("\treturn");
        codeRaw(".end method\n");                 
        dumpScope(); 
    }
#line 1473 "./build/y.tab.c"
    break;

  case 16: /* FunctionParameterStmt: VARIABLE_T IDENT  */
#line 126 "./compiler.y"
                       { functionParmPush((yyvsp[-1].var_type), NULL, (yyvsp[0].s_var)); }
#line 1479 "./build/y.tab.c"
    break;

  case 17: /* FunctionParameterStmt: VARIABLE_T IDENT '[' ']'  */
#line 127 "./compiler.y"
                               { functionParmPush((yyvsp[-3].var_type), NULL, (yyvsp[-2].s_var)); }
#line 1485 "./build/y.tab.c"
    break;

  case 27: /* $@4: %empty  */
#line 148 "./compiler.y"
            { 
            Object *obj = findVariable((yyvsp[0].s_var));
            if(obj){
                printf("IDENT (name=%s, address=%ld)\n", (yyvsp[0].s_var), obj->symbol->addr);
            }
            tempName = (yyvsp[0].s_var);
      }
#line 1497 "./build/y.tab.c"
    break;

  case 28: /* AssignmentStmt: IDENT $@4 AssignmentOperator  */
#line 154 "./compiler.y"
                           { Object *obj = findVariable(tempName); tempType = obj->type; }
#line 1503 "./build/y.tab.c"
    break;

  case 29: /* $@5: %empty  */
#line 155 "./compiler.y"
            { loadArr((yyvsp[0].s_var)); tempName = (yyvsp[0].s_var); isArray = 1; }
#line 1509 "./build/y.tab.c"
    break;

  case 30: /* $@6: %empty  */
#line 155 "./compiler.y"
                                                                                    {
            Object *obj = findVariable((yyvsp[-2].s_var));
            printf("IDENT (name=%s, address=%ld)\n", (yyvsp[-2].s_var), obj->symbol->addr);
     }
#line 1518 "./build/y.tab.c"
    break;

  case 31: /* AssignmentStmt: IDENT $@5 ArrayIndices $@6 AssignmentOperator  */
#line 158 "./compiler.y"
                          { Object *obj = findVariable(tempName); tempType = obj->type; codeRaw("\tiastore"); }
#line 1524 "./build/y.tab.c"
    break;

  case 32: /* AssignmentOperator: VAL_ASSIGN Expression  */
#line 162 "./compiler.y"
                            { 
                              printf("EQL_ASSIGN\n");                             
                              if ((yyvsp[0].obj_val).type != tempType)
                                CastVariable((yyvsp[0].obj_val).type, tempType);
                              if(isArray) isArray = 0;
                              else typeStore(tempName); 
                            }
#line 1536 "./build/y.tab.c"
    break;

  case 33: /* AssignmentOperator: ADD_ASSIGN Expression  */
#line 169 "./compiler.y"
                            { 
                              printf("ADD_ASSIGN\n");                                                               
                              if ((yyvsp[0].obj_val).type != tempType)
                                CastVariable((yyvsp[0].obj_val).type, tempType);
                              Object *obj = findVariable(tempName); 
                              opassignment(obj, "add"); 
                            }
#line 1548 "./build/y.tab.c"
    break;

  case 34: /* AssignmentOperator: SUB_ASSIGN Expression  */
#line 176 "./compiler.y"
                            { 
                              printf("SUB_ASSIGN\n");                               
                              if ((yyvsp[0].obj_val).type != tempType)
                                CastVariable((yyvsp[0].obj_val).type, tempType); 
                              Object *obj = findVariable(tempName); 
                              opassignment(obj, "sub");
                            }
#line 1560 "./build/y.tab.c"
    break;

  case 35: /* AssignmentOperator: MUL_ASSIGN Expression  */
#line 183 "./compiler.y"
                            { 
                              printf("MUL_ASSIGN\n");                               
                              //if ($<obj_val>2.type != tempType)
                                //castVariable($<obj_val>2.type, tempType);
                              Object *obj = findVariable(tempName); 
                              opassignment(obj, "mul");     
                            }
#line 1572 "./build/y.tab.c"
    break;

  case 36: /* AssignmentOperator: DIV_ASSIGN Expression  */
#line 190 "./compiler.y"
                            { 
                              printf("DIV_ASSIGN\n");                               
                              //if ($<obj_val>2.type != tempType)
                                //CastVariable($<obj_val>2.type, tempType);  
                              Object *obj = findVariable(tempName); 
                              opassignment(obj, "div");
                            }
#line 1584 "./build/y.tab.c"
    break;

  case 37: /* AssignmentOperator: REM_ASSIGN Expression  */
#line 197 "./compiler.y"
                            { printf("REM_ASSIGN\n"); Object *obj = findVariable(tempName); logicassignment(obj, "irem"); }
#line 1590 "./build/y.tab.c"
    break;

  case 38: /* AssignmentOperator: SHR_ASSIGN Expression  */
#line 198 "./compiler.y"
                            { printf("SHR_ASSIGN\n"); Object *obj = findVariable(tempName); logicassignment(obj, "iushr"); }
#line 1596 "./build/y.tab.c"
    break;

  case 39: /* AssignmentOperator: SHL_ASSIGN Expression  */
#line 199 "./compiler.y"
                            { printf("SHL_ASSIGN\n"); Object *obj = findVariable(tempName); logicassignment(obj, "ishl"); }
#line 1602 "./build/y.tab.c"
    break;

  case 40: /* AssignmentOperator: BAN_ASSIGN Expression  */
#line 200 "./compiler.y"
                            { printf("BAN_ASSIGN\n"); Object *obj = findVariable(tempName); logicassignment(obj, "iand"); }
#line 1608 "./build/y.tab.c"
    break;

  case 41: /* AssignmentOperator: BOR_ASSIGN Expression  */
#line 201 "./compiler.y"
                            { printf("BOR_ASSIGN\n"); Object *obj = findVariable(tempName); logicassignment(obj, "ior"); }
#line 1614 "./build/y.tab.c"
    break;

  case 42: /* AssignmentOperator: BXO_ASSIGN Expression  */
#line 202 "./compiler.y"
                            { printf("BXO_ASSIGN\n"); Object *obj = findVariable(tempName); logicassignment(obj, "ixor"); }
#line 1620 "./build/y.tab.c"
    break;

  case 43: /* AssignmentOperator: INC_ASSIGN  */
#line 203 "./compiler.y"
                 {  printf("INC_ASSIGN\n"); 
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
#line 1638 "./build/y.tab.c"
    break;

  case 44: /* AssignmentOperator: DEC_ASSIGN  */
#line 216 "./compiler.y"
                 {  printf("DEC_ASSIGN\n"); 
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
#line 1656 "./build/y.tab.c"
    break;

  case 45: /* $@7: %empty  */
#line 233 "./compiler.y"
                            { ifcondition(1); }
#line 1662 "./build/y.tab.c"
    break;

  case 46: /* $@8: %empty  */
#line 233 "./compiler.y"
                                                { printf("IF\n"); pushScope(); }
#line 1668 "./build/y.tab.c"
    break;

  case 47: /* $@9: %empty  */
#line 233 "./compiler.y"
                                                                                                  { ifcondition(0); }
#line 1674 "./build/y.tab.c"
    break;

  case 48: /* $@10: %empty  */
#line 233 "./compiler.y"
                                                                                                                      { dumpScope(); }
#line 1680 "./build/y.tab.c"
    break;

  case 50: /* $@11: %empty  */
#line 234 "./compiler.y"
                            { ifcondition(1); }
#line 1686 "./build/y.tab.c"
    break;

  case 51: /* $@12: %empty  */
#line 234 "./compiler.y"
                                                { printf("IF\n"); }
#line 1692 "./build/y.tab.c"
    break;

  case 52: /* $@13: %empty  */
#line 234 "./compiler.y"
                                                                                 { ifcondition(0); }
#line 1698 "./build/y.tab.c"
    break;

  case 54: /* $@14: %empty  */
#line 238 "./compiler.y"
           { elsecondition(1); }
#line 1704 "./build/y.tab.c"
    break;

  case 55: /* $@15: %empty  */
#line 238 "./compiler.y"
                                 { printf("ELSE\n"); pushScope(); }
#line 1710 "./build/y.tab.c"
    break;

  case 56: /* $@16: %empty  */
#line 238 "./compiler.y"
                                                                                     { elsecondition(0); }
#line 1716 "./build/y.tab.c"
    break;

  case 57: /* ElseStmt: ELSE $@14 $@15 '{' StmtList '}' $@16  */
#line 238 "./compiler.y"
                                                                                                           { dumpScope(); }
#line 1722 "./build/y.tab.c"
    break;

  case 58: /* ElseStmt: %empty  */
#line 239 "./compiler.y"
      { elsecondition(1); elsecondition(0); }
#line 1728 "./build/y.tab.c"
    break;

  case 61: /* $@17: %empty  */
#line 249 "./compiler.y"
            { printf("WHILE\n"); breakwhichLoop = 1; }
#line 1734 "./build/y.tab.c"
    break;

  case 62: /* $@18: %empty  */
#line 249 "./compiler.y"
                                                       { loopwhilecondition(1); }
#line 1740 "./build/y.tab.c"
    break;

  case 63: /* $@19: %empty  */
#line 249 "./compiler.y"
                                                                                                     { loopwhilecondition(2); }
#line 1746 "./build/y.tab.c"
    break;

  case 64: /* $@20: %empty  */
#line 249 "./compiler.y"
                                                                                                                                { pushScope(); }
#line 1752 "./build/y.tab.c"
    break;

  case 65: /* $@21: %empty  */
#line 249 "./compiler.y"
                                                                                                                                                                  { loopwhilecondition(3); }
#line 1758 "./build/y.tab.c"
    break;

  case 66: /* WhileStmt: WHILE $@17 $@18 '(' Expression ')' $@19 $@20 '{' StmtList '}' $@21  */
#line 249 "./compiler.y"
                                                                                                                                                                                             { dumpScope(); }
#line 1764 "./build/y.tab.c"
    break;

  case 67: /* $@22: %empty  */
#line 253 "./compiler.y"
          { printf("FOR\n"); breakwhichLoop = 0; }
#line 1770 "./build/y.tab.c"
    break;

  case 68: /* $@23: %empty  */
#line 253 "./compiler.y"
                                                   { loopforcondition(1); }
#line 1776 "./build/y.tab.c"
    break;

  case 69: /* $@24: %empty  */
#line 253 "./compiler.y"
                                                                            { pushScope(); }
#line 1782 "./build/y.tab.c"
    break;

  case 70: /* $@25: %empty  */
#line 253 "./compiler.y"
                                                                                                               { loopforcondition(2); }
#line 1788 "./build/y.tab.c"
    break;

  case 71: /* $@26: %empty  */
#line 253 "./compiler.y"
                                                                                                                                                     { loopforcondition(3); }
#line 1794 "./build/y.tab.c"
    break;

  case 72: /* ForStmt: FOR $@22 $@23 $@24 '(' ForDefine ')' $@25 '{' StmtList $@26 '}'  */
#line 253 "./compiler.y"
                                                                                                                                                                                  { dumpScope(); }
#line 1800 "./build/y.tab.c"
    break;

  case 74: /* ForDefine: DefineStmt ':' Expression  */
#line 258 "./compiler.y"
                                { tempType = (yyvsp[0].var_type); }
#line 1806 "./build/y.tab.c"
    break;

  case 78: /* $@27: %empty  */
#line 268 "./compiler.y"
      { loopforcondition(5); }
#line 1812 "./build/y.tab.c"
    break;

  case 79: /* IterativeCondition: $@27 Expression  */
#line 268 "./compiler.y"
                                          { loopforcondition(6); }
#line 1818 "./build/y.tab.c"
    break;

  case 81: /* $@28: %empty  */
#line 273 "./compiler.y"
      { loopforcondition(7); }
#line 1824 "./build/y.tab.c"
    break;

  case 82: /* IterativeUpdate: $@28 AssignmentStmt  */
#line 273 "./compiler.y"
                                              { loopforcondition(8); }
#line 1830 "./build/y.tab.c"
    break;

  case 84: /* $@29: %empty  */
#line 279 "./compiler.y"
                 { tempType = (yyvsp[0].var_type); }
#line 1836 "./build/y.tab.c"
    break;

  case 88: /* Variable: IDENT  */
#line 288 "./compiler.y"
            { createVariable(tempType, NULL, (yyvsp[0].s_var), 0); }
#line 1842 "./build/y.tab.c"
    break;

  case 89: /* Variable: IDENT VAL_ASSIGN Expression  */
#line 289 "./compiler.y"
                                  { createVariable((yyvsp[0].obj_val).type, NULL, (yyvsp[-2].s_var), 0); 
                                    tempType = (yyvsp[0].obj_val).type;
                                    Object *obj = findVariable((yyvsp[-2].s_var));
                                    DeclStore((yyvsp[0].obj_val).type, obj); 
                                    if ((yyvsp[0].obj_val).type != tempType)
                                        CastVariable((yyvsp[0].obj_val).type, tempType);
                                  }
#line 1854 "./build/y.tab.c"
    break;

  case 90: /* Variable: IDENT '[' NumberExpression ']'  */
#line 296 "./compiler.y"
                                     { 
        createArr(tempType, 1);
        printf("create array: %d\n", arrayNumber); 
        arrayNumber = 0;    
        createVariable(tempType, NULL, (yyvsp[-3].s_var), 0); 
        storeArr((yyvsp[-3].s_var));  
    }
#line 1866 "./build/y.tab.c"
    break;

  case 91: /* $@30: %empty  */
#line 304 "./compiler.y"
      { createArr(tempType, 1); }
#line 1872 "./build/y.tab.c"
    break;

  case 92: /* Variable: IDENT '[' NumberExpression ']' VAL_ASSIGN $@30 '{' ArrayList '}'  */
#line 304 "./compiler.y"
                                                    { 
        printf("create array: %d\n", arrayNumber); 
        arrayNumber = 0;      
        createVariable(tempType, NULL, (yyvsp[-8].s_var), 0);
        storeArr((yyvsp[-8].s_var)); 
    }
#line 1883 "./build/y.tab.c"
    break;

  case 93: /* Variable: IDENT '[' NumberExpression ']' '[' NumberExpression ']'  */
#line 310 "./compiler.y"
                                                              {  
        createArr(tempType, 0);
        createVariable(tempType, NULL, (yyvsp[-6].s_var), 0);
        printf("create array: %d\n", arrayNumber);   
        arrayNumber = 0;   
        storeArr((yyvsp[-6].s_var));  
    }
#line 1895 "./build/y.tab.c"
    break;

  case 94: /* $@31: %empty  */
#line 320 "./compiler.y"
                    { codeRaw("\tdup"); code("\tldc %d", arrayNumber); }
#line 1901 "./build/y.tab.c"
    break;

  case 95: /* ArrayList: ArrayList ',' $@31 Expression  */
#line 320 "./compiler.y"
                                                                                    { arrayNumber ++; codeRaw("\tiastore"); }
#line 1907 "./build/y.tab.c"
    break;

  case 96: /* $@32: %empty  */
#line 321 "./compiler.y"
      { codeRaw("\tdup"); code("\tldc %d", arrayNumber); }
#line 1913 "./build/y.tab.c"
    break;

  case 97: /* ArrayList: $@32 Expression  */
#line 321 "./compiler.y"
                                                                      { arrayNumber ++; codeRaw("\tiastore"); }
#line 1919 "./build/y.tab.c"
    break;

  case 101: /* BodyStmt: BREAK ';'  */
#line 328 "./compiler.y"
                { breakLoop(breakwhichLoop); }
#line 1925 "./build/y.tab.c"
    break;

  case 102: /* BodyStmt: CONTINUE ';'  */
#line 329 "./compiler.y"
                   { printf("CONTINUE\n"); }
#line 1931 "./build/y.tab.c"
    break;

  case 103: /* $@33: %empty  */
#line 333 "./compiler.y"
                           { codeRaw("\tgetstatic java/lang/System/out Ljava/io/PrintStream;"); }
#line 1937 "./build/y.tab.c"
    break;

  case 104: /* CoutParmListStmt: CoutParmListStmt SHL $@33 Expression  */
#line 333 "./compiler.y"
                                                                                                             { stdoutPrint(&(yyvsp[0].obj_val)); }
#line 1943 "./build/y.tab.c"
    break;

  case 105: /* $@34: %empty  */
#line 334 "./compiler.y"
          { codeRaw("\tgetstatic java/lang/System/out Ljava/io/PrintStream;"); }
#line 1949 "./build/y.tab.c"
    break;

  case 106: /* CoutParmListStmt: SHL $@34 Expression  */
#line 334 "./compiler.y"
                                                                                            { stdoutPrint(&(yyvsp[0].obj_val)); }
#line 1955 "./build/y.tab.c"
    break;

  case 107: /* $@35: %empty  */
#line 338 "./compiler.y"
             { isReturn = 1; if(!strcmp(tempFuncName, "main")) isMain = 1; }
#line 1961 "./build/y.tab.c"
    break;

  case 108: /* ReturnCondition: RETURN $@35 Expression ';'  */
#line 338 "./compiler.y"
                                                                                            { printf("RETURN\n"); returnObject(tempFuncName); }
#line 1967 "./build/y.tab.c"
    break;

  case 109: /* $@36: %empty  */
#line 339 "./compiler.y"
             { isReturn = 1; if(!strcmp(tempFuncName, "main")) isMain = 1; }
#line 1973 "./build/y.tab.c"
    break;

  case 110: /* ReturnCondition: RETURN $@36  */
#line 339 "./compiler.y"
                                                                             { printf("RETURN\n"); returnObject(tempFuncName); }
#line 1979 "./build/y.tab.c"
    break;

  case 112: /* LogicExpression: OrExpression  */
#line 348 "./compiler.y"
                   { (yyval.obj_val) = (yyvsp[0].obj_val); }
#line 1985 "./build/y.tab.c"
    break;

  case 113: /* OrExpression: OrExpression LOR AndExpression  */
#line 352 "./compiler.y"
                                     { 
        // bool check
        printf("LOR\n"); 
        codeRaw("\tior");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 1996 "./build/y.tab.c"
    break;

  case 114: /* OrExpression: AndExpression  */
#line 358 "./compiler.y"
                    { (yyval.obj_val) = (yyvsp[0].obj_val); }
#line 2002 "./build/y.tab.c"
    break;

  case 115: /* AndExpression: AndExpression LAN BitOrExpression  */
#line 362 "./compiler.y"
                                        { 
        // bool check
        printf("LAN\n");
        codeRaw("\tiand");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2013 "./build/y.tab.c"
    break;

  case 116: /* AndExpression: BitOrExpression  */
#line 368 "./compiler.y"
                      { (yyval.obj_val) = (yyvsp[0].obj_val); }
#line 2019 "./build/y.tab.c"
    break;

  case 117: /* BitOrExpression: BitOrExpression BOR BitXorExpression  */
#line 372 "./compiler.y"
                                           { 
        // bool check
        printf("BOR\n"); 
        codeRaw("\tior");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2030 "./build/y.tab.c"
    break;

  case 118: /* BitOrExpression: BitXorExpression  */
#line 378 "./compiler.y"
                       { (yyval.obj_val) = (yyvsp[0].obj_val); }
#line 2036 "./build/y.tab.c"
    break;

  case 119: /* BitXorExpression: BitXorExpression BXO BitAndExpression  */
#line 382 "./compiler.y"
                                            { 
        // bool check
        printf("BXO\n"); 
        codeRaw("\tixor");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2047 "./build/y.tab.c"
    break;

  case 120: /* BitXorExpression: BitAndExpression  */
#line 388 "./compiler.y"
                       { (yyval.obj_val) = (yyvsp[0].obj_val); }
#line 2053 "./build/y.tab.c"
    break;

  case 121: /* BitAndExpression: BitAndExpression BAN EqualExpression  */
#line 392 "./compiler.y"
                                           { 
        // bool check
        printf("BAN\n"); 
        codeRaw("\tiand");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2064 "./build/y.tab.c"
    break;

  case 122: /* BitAndExpression: EqualExpression  */
#line 398 "./compiler.y"
                      { (yyval.obj_val) = (yyvsp[0].obj_val); }
#line 2070 "./build/y.tab.c"
    break;

  case 123: /* EqualExpression: EqualExpression NEQ CompareExpression  */
#line 402 "./compiler.y"
                                            { 
        // bool check
        printf("NEQ\n"); 
        equalornot("if_icmpne");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2081 "./build/y.tab.c"
    break;

  case 124: /* EqualExpression: EqualExpression EQL CompareExpression  */
#line 408 "./compiler.y"
                                            { 
        // bool check
        printf("EQL\n"); 
        equalornot("if_icmpeq");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2092 "./build/y.tab.c"
    break;

  case 125: /* EqualExpression: CompareExpression  */
#line 414 "./compiler.y"
                        { (yyval.obj_val) = (yyvsp[0].obj_val); }
#line 2098 "./build/y.tab.c"
    break;

  case 126: /* CompareExpression: CompareExpression GTR ShiftExpression  */
#line 418 "./compiler.y"
                                            { 
        // bool check
        printf("GTR\n"); 
        greaterlower(&(yyvsp[-2].obj_val), "ifgt");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2109 "./build/y.tab.c"
    break;

  case 127: /* CompareExpression: CompareExpression LES ShiftExpression  */
#line 424 "./compiler.y"
                                            { 
        // bool check
        printf("LES\n"); 
        greaterlower(&(yyvsp[-2].obj_val), "iflt");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2120 "./build/y.tab.c"
    break;

  case 128: /* CompareExpression: CompareExpression GEQ ShiftExpression  */
#line 430 "./compiler.y"
                                            { 
        // bool check
        printf("GEQ\n"); 
        greaterlower(&(yyvsp[-2].obj_val), "ifge");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2131 "./build/y.tab.c"
    break;

  case 129: /* CompareExpression: CompareExpression LEQ ShiftExpression  */
#line 436 "./compiler.y"
                                            { 
        // bool check
        printf("LEQ\n"); 
        greaterlower(&(yyvsp[-2].obj_val), "ifle");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2142 "./build/y.tab.c"
    break;

  case 130: /* CompareExpression: ShiftExpression  */
#line 442 "./compiler.y"
                      { (yyval.obj_val) = (yyvsp[0].obj_val); }
#line 2148 "./build/y.tab.c"
    break;

  case 131: /* ShiftExpression: ShiftExpression SHR AddOPExpression  */
#line 446 "./compiler.y"
                                          { 
        // bool check
        printf("SHR\n"); 
        codeRaw("\tiushr");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2159 "./build/y.tab.c"
    break;

  case 132: /* ShiftExpression: AddOPExpression  */
#line 452 "./compiler.y"
                      { (yyval.obj_val) = (yyvsp[0].obj_val); }
#line 2165 "./build/y.tab.c"
    break;

  case 133: /* AddOPExpression: AddOPExpression ADD MulOPExpression  */
#line 456 "./compiler.y"
                                          { 
        // bool check
        printf("ADD\n");
        if((yyvsp[-2].obj_val).type == OBJECT_TYPE_FLOAT) codeRaw("\tfadd");
        else codeRaw("\tiadd");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2177 "./build/y.tab.c"
    break;

  case 134: /* AddOPExpression: AddOPExpression SUB MulOPExpression  */
#line 463 "./compiler.y"
                                          { 
        // bool check
        printf("SUB\n"); 
        if((yyvsp[-2].obj_val).type == OBJECT_TYPE_FLOAT) codeRaw("\tfsub");
        else codeRaw("\tisub");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2189 "./build/y.tab.c"
    break;

  case 135: /* AddOPExpression: MulOPExpression  */
#line 470 "./compiler.y"
                      { (yyval.obj_val) = (yyvsp[0].obj_val); }
#line 2195 "./build/y.tab.c"
    break;

  case 136: /* MulOPExpression: MulOPExpression MUL CastExpression  */
#line 474 "./compiler.y"
                                         { 
        // bool check
        printf("MUL\n"); 
        if((yyvsp[-2].obj_val).type == OBJECT_TYPE_FLOAT) codeRaw("\tfmul");
        else codeRaw("\timul");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2207 "./build/y.tab.c"
    break;

  case 137: /* MulOPExpression: MulOPExpression DIV CastExpression  */
#line 481 "./compiler.y"
                                         { 
        // bool check
        printf("DIV\n"); 
        if((yyvsp[-2].obj_val).type == OBJECT_TYPE_FLOAT) codeRaw("\tfdiv");
        else codeRaw("\tidiv");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2219 "./build/y.tab.c"
    break;

  case 138: /* MulOPExpression: MulOPExpression REM CastExpression  */
#line 488 "./compiler.y"
                                         { 
        // bool check
        printf("REM\n"); 
        codeRaw("\tirem");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2230 "./build/y.tab.c"
    break;

  case 139: /* MulOPExpression: CastExpression  */
#line 494 "./compiler.y"
                     { (yyval.obj_val) = (yyvsp[0].obj_val); }
#line 2236 "./build/y.tab.c"
    break;

  case 140: /* CastExpression: '(' VARIABLE_T ')' UnsignNumberExpression  */
#line 498 "./compiler.y"
                                                { 
        // bool check
        CastVariable((yyvsp[0].obj_val).type, (yyvsp[-2].var_type));
        (yyval.obj_val).type = (yyvsp[-2].var_type);
      }
#line 2246 "./build/y.tab.c"
    break;

  case 141: /* CastExpression: UnsignNumberExpression  */
#line 503 "./compiler.y"
                             { (yyval.obj_val) = (yyvsp[0].obj_val); }
#line 2252 "./build/y.tab.c"
    break;

  case 142: /* UnsignNumberExpression: SUB UnsignNumberExpression  */
#line 507 "./compiler.y"
                                 { 
        // bool check
        printf("NEG\n"); 
        if((yyvsp[0].obj_val).type == OBJECT_TYPE_INT) codeRaw("\tineg");
        else codeRaw("\tfneg");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2264 "./build/y.tab.c"
    break;

  case 143: /* UnsignNumberExpression: NOT UnsignNumberExpression  */
#line 514 "./compiler.y"
                                 { 
        // bool check
        printf("NOT\n"); 
        codeRaw("\ticonst_1");
        codeRaw("\tixor");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2276 "./build/y.tab.c"
    break;

  case 144: /* UnsignNumberExpression: LogicNotExpression  */
#line 521 "./compiler.y"
                         { (yyval.obj_val) = (yyvsp[0].obj_val); }
#line 2282 "./build/y.tab.c"
    break;

  case 145: /* LogicNotExpression: BNT LogicNotExpression  */
#line 525 "./compiler.y"
                             { 
        // bool check
        printf("BNT\n"); 
        codeRaw("\ticonst_m1");
        codeRaw("\tixor");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2294 "./build/y.tab.c"
    break;

  case 146: /* LogicNotExpression: BAN LogicNotExpression  */
#line 532 "./compiler.y"
                             { 
        // bool check
        printf("BAN\n"); 
        codeRaw("\tiand");
        (yyval.obj_val) = (yyvsp[0].obj_val); 
      }
#line 2305 "./build/y.tab.c"
    break;

  case 147: /* LogicNotExpression: PrimaryExpression  */
#line 538 "./compiler.y"
                        { (yyval.obj_val) = (yyvsp[0].obj_val); }
#line 2311 "./build/y.tab.c"
    break;

  case 148: /* PrimaryExpression: '(' Expression ')'  */
#line 542 "./compiler.y"
                         { (yyval.obj_val) = (yyvsp[-1].obj_val); }
#line 2317 "./build/y.tab.c"
    break;

  case 149: /* PrimaryExpression: CallFunction  */
#line 543 "./compiler.y"
                   { (yyval.obj_val) = (yyvsp[0].obj_val); }
#line 2323 "./build/y.tab.c"
    break;

  case 150: /* PrimaryExpression: CHAR_LIT  */
#line 544 "./compiler.y"
                {   printf("CHAR_LIT \'%c\'\n", (yyvsp[0].c_var));              
                    code("\tldc %d", (yyvsp[0].c_var));
                    (yyval.obj_val).type = OBJECT_TYPE_CHAR; }
#line 2331 "./build/y.tab.c"
    break;

  case 151: /* PrimaryExpression: STR_LIT  */
#line 547 "./compiler.y"
                {   printf("STR_LIT \"%s\"\n", (yyvsp[0].s_var));              
                    code("\tldc \"%s\"", (yyvsp[0].s_var));
                    (yyval.obj_val).type = OBJECT_TYPE_STR; }
#line 2339 "./build/y.tab.c"
    break;

  case 155: /* PrimaryExpression: ArrayExpression  */
#line 553 "./compiler.y"
                      { (yyval.obj_val).type = tempType; }
#line 2345 "./build/y.tab.c"
    break;

  case 156: /* CallFunction: IDENT '(' FunctionList ')'  */
#line 557 "./compiler.y"
                                 {
        Object *obj = findVariable((yyvsp[-3].s_var));
        printf("IDENT (name=%s, address=%ld)\n", (yyvsp[-3].s_var), obj->symbol->addr);
        printf("call: %s%s\n", obj->symbol->name, obj->symbol->func_sig);
        (yyval.obj_val).type = obj->type;
        code("\tinvokestatic Main/%s%s", obj->symbol->name, obj->symbol->func_sig);
    }
#line 2357 "./build/y.tab.c"
    break;

  case 160: /* IdentExpression: IDENT  */
#line 573 "./compiler.y"
            { 
            Object *obj = findVariable((yyvsp[0].s_var));
            if(obj){
                printf("IDENT (name=%s, address=%ld)\n", (yyvsp[0].s_var), obj->symbol->addr);
                typeload((yyvsp[0].s_var));                
                (yyval.obj_val).symbol = (SymbolData*)malloc(sizeof(SymbolData));
                (yyval.obj_val).symbol->name = (yyvsp[0].s_var);
                (yyval.obj_val).type = obj->type;
            }
            else{
                printf("IDENT (name=%s, address=-1)\n", (yyvsp[0].s_var));
                codeRaw("\tldc \"\n\"");
                (yyval.obj_val).type = OBJECT_TYPE_STR;
            }
      }
#line 2377 "./build/y.tab.c"
    break;

  case 161: /* $@37: %empty  */
#line 591 "./compiler.y"
            { loadArr((yyvsp[0].s_var)); }
#line 2383 "./build/y.tab.c"
    break;

  case 162: /* $@38: %empty  */
#line 591 "./compiler.y"
                                                 {
            Object *obj = findVariable((yyvsp[-2].s_var));
            printf("IDENT (name=%s, address=%ld)\n", (yyvsp[-2].s_var), obj->symbol->addr);
            tempType = obj->type;
     }
#line 2393 "./build/y.tab.c"
    break;

  case 163: /* ArrayExpression: IDENT $@37 ArrayIndices $@38  */
#line 595 "./compiler.y"
       { codeRaw("\tiaload"); }
#line 2399 "./build/y.tab.c"
    break;

  case 164: /* $@39: %empty  */
#line 599 "./compiler.y"
                       { codeRaw("\taaload"); }
#line 2405 "./build/y.tab.c"
    break;

  case 167: /* NumberExpression: INT_LIT  */
#line 605 "./compiler.y"
                {  printf("INT_LIT %d\n", (yyvsp[0].i_var));
                   if(!(isMain && isReturn)) {
                       code("\tldc %d", (yyvsp[0].i_var));
                   }
                   else{
                       isMain = 0;
                       isReturn = 0;
                   }
                   (yyval.obj_val).type = OBJECT_TYPE_INT;   }
#line 2419 "./build/y.tab.c"
    break;

  case 168: /* NumberExpression: FLOAT_LIT  */
#line 614 "./compiler.y"
                {  printf("FLOAT_LIT %f\n", (yyvsp[0].f_var));
                   code("\tldc %f", (yyvsp[0].f_var));
                   (yyval.obj_val).type = OBJECT_TYPE_FLOAT; }
#line 2427 "./build/y.tab.c"
    break;

  case 169: /* BoolExpression: BOOL_LIT  */
#line 620 "./compiler.y"
               {   printf("BOOL_LIT %s\n", (yyvsp[0].b_var) ? "TRUE" : "FALSE");
                   code("\ticonst_%d", (yyvsp[0].b_var) ? 1 : 0);                    
                   (yyval.obj_val).type = OBJECT_TYPE_BOOL; }
#line 2435 "./build/y.tab.c"
    break;


#line 2439 "./build/y.tab.c"

      default: break;
    }
  /* User semantic actions sometimes alter yychar, and that requires
     that yytoken be updated with the new translation.  We take the
     approach of translating immediately before every use of yytoken.
     One alternative is translating here after every semantic action,
     but that translation would be missed if the semantic action invokes
     YYABORT, YYACCEPT, or YYERROR immediately after altering yychar or
     if it invokes YYBACKUP.  In the case of YYABORT or YYACCEPT, an
     incorrect destructor might then be invoked immediately.  In the
     case of YYERROR or YYBACKUP, subsequent parser actions might lead
     to an incorrect destructor call or verbose syntax error message
     before the lookahead is translated.  */
  YY_SYMBOL_PRINT ("-> $$ =", YY_CAST (yysymbol_kind_t, yyr1[yyn]), &yyval, &yyloc);

  YYPOPSTACK (yylen);
  yylen = 0;

  *++yyvsp = yyval;

  /* Now 'shift' the result of the reduction.  Determine what state
     that goes to, based on the state we popped back to and the rule
     number reduced by.  */
  {
    const int yylhs = yyr1[yyn] - YYNTOKENS;
    const int yyi = yypgoto[yylhs] + *yyssp;
    yystate = (0 <= yyi && yyi <= YYLAST && yycheck[yyi] == *yyssp
               ? yytable[yyi]
               : yydefgoto[yylhs]);
  }

  goto yynewstate;


/*--------------------------------------.
| yyerrlab -- here on detecting error.  |
`--------------------------------------*/
yyerrlab:
  /* Make sure we have latest lookahead translation.  See comments at
     user semantic actions for why this is necessary.  */
  yytoken = yychar == YYEMPTY ? YYSYMBOL_YYEMPTY : YYTRANSLATE (yychar);
  /* If not already recovering from an error, report this error.  */
  if (!yyerrstatus)
    {
      ++yynerrs;
      yyerror (YY_("syntax error"));
    }

  if (yyerrstatus == 3)
    {
      /* If just tried and failed to reuse lookahead token after an
         error, discard it.  */

      if (yychar <= YYEOF)
        {
          /* Return failure if at end of input.  */
          if (yychar == YYEOF)
            YYABORT;
        }
      else
        {
          yydestruct ("Error: discarding",
                      yytoken, &yylval);
          yychar = YYEMPTY;
        }
    }

  /* Else will try to reuse lookahead token after shifting the error
     token.  */
  goto yyerrlab1;


/*---------------------------------------------------.
| yyerrorlab -- error raised explicitly by YYERROR.  |
`---------------------------------------------------*/
yyerrorlab:
  /* Pacify compilers when the user code never invokes YYERROR and the
     label yyerrorlab therefore never appears in user code.  */
  if (0)
    YYERROR;
  ++yynerrs;

  /* Do not reclaim the symbols of the rule whose action triggered
     this YYERROR.  */
  YYPOPSTACK (yylen);
  yylen = 0;
  YY_STACK_PRINT (yyss, yyssp);
  yystate = *yyssp;
  goto yyerrlab1;


/*-------------------------------------------------------------.
| yyerrlab1 -- common code for both syntax error and YYERROR.  |
`-------------------------------------------------------------*/
yyerrlab1:
  yyerrstatus = 3;      /* Each real token shifted decrements this.  */

  /* Pop stack until we find a state that shifts the error token.  */
  for (;;)
    {
      yyn = yypact[yystate];
      if (!yypact_value_is_default (yyn))
        {
          yyn += YYSYMBOL_YYerror;
          if (0 <= yyn && yyn <= YYLAST && yycheck[yyn] == YYSYMBOL_YYerror)
            {
              yyn = yytable[yyn];
              if (0 < yyn)
                break;
            }
        }

      /* Pop the current state because it cannot handle the error token.  */
      if (yyssp == yyss)
        YYABORT;


      yydestruct ("Error: popping",
                  YY_ACCESSING_SYMBOL (yystate), yyvsp);
      YYPOPSTACK (1);
      yystate = *yyssp;
      YY_STACK_PRINT (yyss, yyssp);
    }

  YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN
  *++yyvsp = yylval;
  YY_IGNORE_MAYBE_UNINITIALIZED_END


  /* Shift the error token.  */
  YY_SYMBOL_PRINT ("Shifting", YY_ACCESSING_SYMBOL (yyn), yyvsp, yylsp);

  yystate = yyn;
  goto yynewstate;


/*-------------------------------------.
| yyacceptlab -- YYACCEPT comes here.  |
`-------------------------------------*/
yyacceptlab:
  yyresult = 0;
  goto yyreturnlab;


/*-----------------------------------.
| yyabortlab -- YYABORT comes here.  |
`-----------------------------------*/
yyabortlab:
  yyresult = 1;
  goto yyreturnlab;


/*-----------------------------------------------------------.
| yyexhaustedlab -- YYNOMEM (memory exhaustion) comes here.  |
`-----------------------------------------------------------*/
yyexhaustedlab:
  yyerror (YY_("memory exhausted"));
  yyresult = 2;
  goto yyreturnlab;


/*----------------------------------------------------------.
| yyreturnlab -- parsing is finished, clean up and return.  |
`----------------------------------------------------------*/
yyreturnlab:
  if (yychar != YYEMPTY)
    {
      /* Make sure we have latest lookahead translation.  See comments at
         user semantic actions for why this is necessary.  */
      yytoken = YYTRANSLATE (yychar);
      yydestruct ("Cleanup: discarding lookahead",
                  yytoken, &yylval);
    }
  /* Do not reclaim the symbols of the rule whose action triggered
     this YYABORT or YYACCEPT.  */
  YYPOPSTACK (yylen);
  YY_STACK_PRINT (yyss, yyssp);
  while (yyssp != yyss)
    {
      yydestruct ("Cleanup: popping",
                  YY_ACCESSING_SYMBOL (+*yyssp), yyvsp);
      YYPOPSTACK (1);
    }
#ifndef yyoverflow
  if (yyss != yyssa)
    YYSTACK_FREE (yyss);
#endif

  return yyresult;
}

#line 625 "./compiler.y"

/* C code section */
