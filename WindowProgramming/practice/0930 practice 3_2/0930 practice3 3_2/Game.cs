using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _0930_practice3_3_2
{
    class Game
    {
        public bool canplace(int N)
        {
            
            if(N == 0)
            {
                return true;
            }
            else if(N >= 4)
            {
                return false;
            }
            return true;
        }
        public bool cantake(int N)
        {
            if (N == 0)
            {
                return false;
            }
            else if (N < 4)
            {
                return true;
            }
            return true;
        }
    }
    class Check
    {
        int oneN = 3, twoN = 3, threeN = 3, lineN;
        public bool canplay(string Text)
        {
            lineN = 4;
            int i = 1;
            foreach (var c in Text)
            {
                if (oneN < 0 || twoN < 0 || threeN < 0)
                {
                    return false;
                }
                
                if (i % 2 != 0)
                {
                    lineN--;
                    if(lineN < 0)
                    {
                        return false;
                    }
                    if (c != '1' && c != '2' && c != '3')
                    {
                        return false;
                    }
                    else if (c == '1')
                    {
                        oneN -= 1;
                    }
                    else if (c == '2')
                    {
                        twoN -= 1;
                    }
                    else if (c == '3')
                    {
                        threeN -= 1;
                    }

                }
                else
                {
                    if (c != ' ')
                    {
                        return false;
                    }
                }
                i++;
            }
            return true;
        }
    }
}