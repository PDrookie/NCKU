using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0923_practice_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] pieces = new string[9, 9];
            for(int i = 1; i <= 8; i++)
            {
                pieces[i, 0] = Convert.ToString(i);
                for(int j = 1; j <= 8; j++)
                {
                    pieces[i, j] = "-";
                }
            }
            pieces[0, 0] = " ";
            pieces[0, 1] = "A";
            pieces[0, 2] = "B";
            pieces[0, 3] = "C";
            pieces[0, 4] = "D";
            pieces[0, 5] = "E";
            pieces[0, 6] = "F";
            pieces[0, 7] = "G";
            pieces[0, 8] = "H";

            int num = 0, turn = 1 ;
            int cross, circle;
            string playerX, playerO, player;
            string position;
            
            for(; ; )
            {
                num = 0;
                cross = 0;
                circle = 0;
               for(int i = 0; i <= 8; i++)
                {
                    for(int j = 0; j <= 8; j++)
                    {
                        Console.Write(pieces[i, j] + " ");
                        if (pieces[i, j] == "-")
                        {
                            num++;
                        }
                        if (pieces[i, j] == "X")
                        {
                            cross++;
                        }
                        if (pieces[i, j] == "O")
                        {
                            circle++;
                        }
                    }
                   Console.WriteLine(); 
                }               
                             
                if (num == 0)
                {
                    if (cross > circle)
                    {
                        Console.WriteLine("遊戲結束 玩家X獲勝！");
                    }
                    else
                    {
                        Console.WriteLine("遊戲結束 玩家O獲勝！");
                    }
                    break;
                }
                else
                {
                    if (turn % 2 == 0)
                    {
                        player = "X";
                    }
                    else
                    {
                        player = "O";
                    }
                    turn++;
                    Console.WriteLine("輪到玩家{0} 請輸入要下的位置：", player);
                    position = Console.ReadLine();
                    ChessPlaying(position, player, pieces);
                }
                
                
            }
            Console.ReadLine();
        }
        static void ChessPlaying(string position, string player, string[,] pieces)
        {
            int diff;
            int start, end;
            byte[] array = System.Text.Encoding.ASCII.GetBytes(position.Substring(0));
            int col = (int)array[0] - 64;
            int row = Convert.ToInt32(position.Substring(1));
            if (pieces[row, col] == "-")
            {
                pieces[row, col] = player;
            }
            else
            {
                Console.WriteLine("此位置已有棋子！ 按任一鍵繼續遊戲");
                Console.ReadLine();
                return;
            }
            for (int i = 8; i > col; i--)//right
            {
                diff = 0;
                if (pieces[row, i] == player)
                {
                    diff++;    
                }
                if(diff != 0)
                {
                    for(int j = 8; j > col ; j--)
                    {
                        if(pieces[row, j] != player && pieces[row, j] != "-")
                        {
                            pieces[row, j] = player;
                        }
                    }
                }                
            }
            for (int i = 1; i < col; i++)//left
            {
                diff = 0;
                if (pieces[row, i] == player)
                {
                    diff++;
                }
                if (diff != 0)
                {
                    for (int j = 1; j < col; j++)
                    {
                        if (pieces[row, j] != player && pieces[row, j] != "-")
                        {
                            pieces[row, j] = player;
                        }
                    }
                }
            }
            for (int i = 8; i > row; i--)//up
            {
                diff = 0;
                if (pieces[i, col] == player)
                {
                    diff++;
                }
                if (diff != 0)
                {
                    for (int j = 8; j > row; j--)
                    {
                        if (pieces[j, col] != player && pieces[j, col] != "-")
                        {
                            pieces[j, col] = player;
                        }
                    }
                }
            }
            for (int i = 1; i < row; i++)//down
            {
                diff = 0;
                if (pieces[i, col] == player)
                {
                    diff++;
                }
                if (diff != 0)
                {
                    for (int j = 1; j < row; j++)
                    {
                        if (pieces[j, col] != player && pieces[j, col] != "-")
                        {
                            pieces[j, col] = player;
                        }
                    }
                }

            }
        }
    }
}
