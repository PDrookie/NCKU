    .class public Main
    .super java/lang/Object
    .method public static calculate_pi(I)F
    	.limit stack 20
    	.limit locals 20
    	ldc 3.000000
    	fstore 1 ; pi
    	ldc 2.000000
    	fstore 2 ; two
    	iconst_1
    	istore 3 ; add
    L_for_1:
        	ldc 1
        	istore 4 ; k
        L_for_cond_1:
        	iload 4 ; k
        	iload 0 ; terms
        	isub
        	iflt L_cmp_0
        	iconst_0
        	goto L_cmp_1
        L_cmp_0:
        	iconst_1
        L_cmp_1:
        	ifeq L_after_for_1
        	goto L_for_body_1
        L_for_update_1:
        	iload 4 ; k
        	iconst_1
        	iadd
        	istore 4 ; k
        	goto L_for_cond_1
        L_for_body_1:
        	ldc 4
        	i2f
        	fload 2 ; two
        	iload 4 ; k
        	i2f
        	fmul
        	fload 2 ; two
        	iload 4 ; k
        	i2f
        	fmul
        	ldc 1.000000
        	fadd
        	fmul
        	fload 2 ; two
        	iload 4 ; k
        	i2f
        	fmul
        	fload 2 ; two
        	fadd
        	fmul
        	fdiv
        	fstore 5 ; term
        	iload 3 ; add
        	ifeq L_if_0
            	fload 5 ; term
            	fload 1 ; pi
            	swap
            	fadd
            	fstore 1 ; pi
            	iconst_0
            	istore 3 ; add
            	goto L_else_1
            L_if_0:
        L_else_0:
            	fload 5 ; term
            	fload 1 ; pi
            	swap
            	fsub
            	fstore 1 ; pi
            	iconst_1
            	istore 3 ; add
            L_else_1:
        	goto L_for_update_1
        L_after_for_1:
    	fload 1 ; pi
    	freturn 
    .end method

    .method public static main([Ljava/lang/String;)V
    	.limit stack 100
    	.limit locals 100
    	ldc 100
    	istore 1 ; terms
    	iload 1 ; terms
    	invokestatic Main/calculate_pi(I)F
    	fstore 2 ; pi
    	getstatic java/lang/System/out Ljava/io/PrintStream;
    	ldc "Approximation of Pi after "
    	invokevirtual java/io/PrintStream/print(Ljava/lang/String;)V

    	getstatic java/lang/System/out Ljava/io/PrintStream;
    	iload 1 ; terms
    	invokevirtual java/io/PrintStream/print(I)V

    	getstatic java/lang/System/out Ljava/io/PrintStream;
    	ldc " terms: "
    	invokevirtual java/io/PrintStream/print(Ljava/lang/String;)V

    	getstatic java/lang/System/out Ljava/io/PrintStream;
    	fload 2 ; pi
    	invokevirtual java/io/PrintStream/print(F)V

    	getstatic java/lang/System/out Ljava/io/PrintStream;
    	ldc "
"
    	invokevirtual java/io/PrintStream/print(Ljava/lang/String;)V

    	return
    	return
    .end method

