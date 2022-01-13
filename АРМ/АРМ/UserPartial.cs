using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ
{
    partial class User
    {
        public override string ToString()
        {
            return $"{Id} ({Login}, {Password}, {Lvl})";
        }
    }
}
