using System;
using System.Collections.Generic;

#nullable disable

namespace АРМ
{
    public partial class Bank
    {
        public Bank()
        {
            Providers = new HashSet<Provider>();
        }

        public int Id { get; set; }
        public string NameBank { get; set; }
        public int? LvlLicenses { get; set; }
        public int? Active { get; set; }

        public virtual ICollection<Provider> Providers { get; set; }
    }
}
