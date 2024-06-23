using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _1014_practice_5_2
{
    class ranger
    {
        public int hp = 90;
        public int mp = 10;
        public int atk = 30;
        public int attackrange = 3;
        public int moverange = 1;
        public virtual void arrow()
        {
            this.attackrange++;
        }

    }
    class warrior
    {
        public int hp = 100;
        public int mp = 15;
        public int atk = 30;
        public int attackrange = 1;
        public int moverange = 2;
        public virtual int chop()
        {
            int damage = this.hp;
            this.hp += this.atk / 2;
            return damage;
        }

    }
    class magician
    {
        public int hp = 70;
        public int mp = 25;
        public int atk = 20;
        public int attackrange = 2;
        public int moverange = 2;
        public virtual int magic()
        {
            int damage = this.atk * 2;
            return damage;
        }

    }

    class P1_warrior : warrior
    {

    }
    class P1_magician : magician
    {

    }
    class P1_ranger : ranger
    {

    }

    class P2_warrior : warrior
    {

    }
    class P2_magician : magician
    {

    }
    class P2_ranger : ranger
    {

    }

}