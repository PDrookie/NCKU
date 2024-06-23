using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _0930_practice_3_1
{
    class Account
    {
        public string link, user, pass;
        public Account(string _link, string _user, string _pass)
        {
            link = _link;
            user = _user;
            pass = _pass;
        }

        public override bool Equals(object value)
        {
            return link == ((Account)value).link && user == ((Account)value).user && pass == ((Account)value).pass;
        }

        public static bool operator ==(Account a, Account b)
        {
            return a.link == b.link && a.user == b.user && a.pass == b.pass;
        }
        public static bool operator !=(Account a, Account b)
        {
            return !(a.link == b.link && a.user == b.user && a.pass == b.pass);
        }
    }
}