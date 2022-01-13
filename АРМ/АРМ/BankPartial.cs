using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ
{
    partial class Bank
    {
        public override string ToString()
        {
            return $"{Id} ({NameBank}, {LvlLicenses}, {Active})";
        }
    }
}

//namespace АРМ
//{
//    static class BankExt
//    {
//        public static string ToStr(this Bank bank)
//        {
//            return $"{bank.Id} ({bank.NameBank}, {bank.LvlLicenses}, {bank.Active})";
//        }
//    }
//}
