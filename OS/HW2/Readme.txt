有提供三組測試資料
kernel module:
step.
$ make
step.
$ make load
---
userspace program :
step.
$ gcc -o MT_matrix MT_matrix.c -lpthread
step.
$ sudo ./MT_matrix 2 m1_1.txt m2_1.txt

可以印出thread information
並比較產生的result 與 answer 的結果
測試方式以此類推
