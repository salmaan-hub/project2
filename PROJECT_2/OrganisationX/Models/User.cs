using System;
using System.Collections.Generic;

namespace OrganisationX.Models
{
    public partial class User
    {
        public string UserId { get; set; }
        public int? Age { get; set; }

        public virtual AspNetUsers UserNavigation { get; set; }
    }
}
