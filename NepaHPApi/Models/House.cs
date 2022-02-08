using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NepaHPApi.Models
{
    public partial class House
    {
        public House()
        {
            Persons = new HashSet<Person>();
        }

        public int HouseId { get; set; }
        public string HouseName { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}
