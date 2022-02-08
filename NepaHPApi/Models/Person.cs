using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NepaHPApi.Models
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int? HouseId { get; set; }
        public int? OccupationId { get; set; }

        public virtual House House { get; set; }
        public virtual Occupation Occupation { get; set; }
    }
}
