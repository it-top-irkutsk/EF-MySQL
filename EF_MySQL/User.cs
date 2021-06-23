using System;
using System.Collections.Generic;

#nullable disable

namespace EF_MySQL
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsActive { get; set; }
    }
}
