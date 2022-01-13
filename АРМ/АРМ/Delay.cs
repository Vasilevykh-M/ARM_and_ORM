using System;
using System.Collections.Generic;

#nullable disable

namespace АРМ
{
    public partial class Delay
    {
        public int IdProduct { get; set; }
        public int IdProvider { get; set; }

        public virtual Product IdProductNavigation { get; set; }
        public virtual Provider IdProviderNavigation { get; set; }
    }
}
