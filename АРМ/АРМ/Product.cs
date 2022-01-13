using System;
using System.Collections.Generic;

#nullable disable

namespace АРМ
{
    public partial class Product
    {
        public Product()
        {
            Delays = new HashSet<Delay>();
        }

        public int Id { get; set; }
        public int? IdGroop { get; set; }
        public string NamePr { get; set; }
        public bool? Instruct { get; set; }
        public int? Term { get; set; }
        public int? CostPr { get; set; }

        public virtual ICollection<Delay> Delays { get; set; }
    }
}
