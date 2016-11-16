using System;
using System.Collections.Generic;

namespace HRSmart.Domain.Entities
{
    public partial class address
    {
        public int id { get; set; }
        public string localisation { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public Nullable<int> buisness_id { get; set; }
        public virtual buisness buisness { get; set; }
    }
}
