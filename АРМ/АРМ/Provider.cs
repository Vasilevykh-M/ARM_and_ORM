using System;
using System.Collections.Generic;

#nullable disable

namespace АРМ
{
    public partial class Provider
    {
        public Provider()
        {
            Delays = new HashSet<Delay>();
        }

        public int Id { get; set; }
        public string NamePr { get; set; }
        public int? IdBank { get; set; }
        public string CodePayment { get; set; }
        public int? CountDelays { get; set; }
        public DateTime? DataCoop { get; set; }

        public virtual Bank IdBankNavigation { get; set; }
        public virtual ICollection<Delay> Delays { get; set; }
    }
}
