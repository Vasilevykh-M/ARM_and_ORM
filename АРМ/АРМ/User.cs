using System;
using System.Collections.Generic;

#nullable disable

namespace АРМ
{
    public partial class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Lvl { get; set; }
    }
}
