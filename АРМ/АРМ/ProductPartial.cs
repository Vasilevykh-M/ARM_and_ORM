using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ
{
    partial class Product
    {
        public override string ToString()
        {
            return $"{Id} ({IdGroop}, {NamePr}, {Instruct}, {Term}, {CostPr})";
        }
    }
}
