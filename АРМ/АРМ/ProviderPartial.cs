using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ
{
    partial class Provider
    {
        public override string ToString()
        {
            return $"{Id} ({NamePr}, {IdBank}, {CodePayment}, {CountDelays}, {DataCoop})";
        }
    }
}
