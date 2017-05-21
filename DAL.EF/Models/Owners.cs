using System;
using System.Collections.Generic;

namespace DAL.EF.Models
{
    public partial class Owners
    {
        public Owners()
        {
            Devices = new HashSet<Devices>();
        }

        public int OwnerId { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Devices> Devices { get; set; }
    }
}
