using System;
using System.Collections.Generic;

namespace DAL.EF.Models
{
    public partial class Devices
    {
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public DateTime Created { get; set; }

        public virtual Owners Owner { get; set; }
    }
}
