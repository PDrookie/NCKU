using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int cash = 0, counting;
            double percent;
            int ExpenditureProject;
            int Expenditure = 0;
            int eat = 0, clothes = 0, live = 0, traffic = 0, fun = 0;
            int method;
            for (; ; )
            {
                Console.WriteLine("(1)輸入收入 (2)輸入支出 (3)計算比例 (4)剩餘金額 (5)退出程式");
                Console.Write("輸入數字選擇功能: ");
                method = Convert.ToInt32(Console.ReadLine());

                switch (method)
                {
                    case 1:
                        Console.Write("輸入金額:");
                        counting = Convert.ToInt32(Console.ReadLine());
                        cash += counting;
                        break;
                    case 2:
                        Expenditure = 0;
                        Console.WriteLine("(1)食 (2)衣 (3)住 (4)行 (5)育樂");
                        Console.Write("輸入數字選擇支出項目:");
                        ExpenditureProject = Convert.ToInt32(Console.ReadLine());
                        Console.Write("輸入支出金額:");
                        counting = Convert.ToInt32(Console.ReadLine());
                        switch (ExpenditureProject)
                        {
                            case 1:
                                eat += counting;
                                //Console.WriteLine(eat);
                                break;
                            case 2:
                                clothes += counting;
                                //Console.WriteLine(clothes);
                                break;
                            case 3:
                                live += counting;
                                //Console.WriteLine(live);
                                break;
                            case 4:
                                traffic += counting;
                                //Console.WriteLine(traffic);
                                break;
                            case 5:
                                fun += counting;
                                //Console.WriteLine(fun);
                                break;
                        }
                        //Console.WriteLine(Expenditure);
                        Expenditure = eat + clothes + live + traffic + fun;
                        //Console.WriteLine(Expenditure + "after");
                        break;
                    case 3:
                        percent = (double) eat / Expenditure;
                        percent *= 100;
                        Console.WriteLine("食: " + percent + "%");
                        percent = (double) clothes / Expenditure;
                        percent *= 100;
                        Console.WriteLine("衣: " + percent + "%");
                        percent = (double) live / Expenditure;
                        percent *= 100;
                        Console.WriteLine("住: " + percent + "%");
                        percent = (double) traffic / Expenditure;
                        percent *= 100;
                        Console.WriteLine("行: " + percent + "%");
                        percent = (double) fun / Expenditure;
                        percent *= 100;
                        Console.WriteLine("育樂: " + percent + "%");
                        break;
                    case 4:
                        Console.WriteLine("剩餘金額為:{0} " , cash - Expenditure);                        
                        break;
                }
                if (method == 5)
                    break;
                else
                    Console.WriteLine();
                    
            }
            Console.ReadLine();

        }
    }
}
