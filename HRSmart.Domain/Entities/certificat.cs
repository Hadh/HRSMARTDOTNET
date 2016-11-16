using System;
using System.Collections.Generic;

namespace HRSmart.Domain.Entities
{
    public partial class certificat
    {
        public certificat()
        {
            this.userskills = new List<userskill>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> skill_id { get; set; }
        public virtual skill skill { get; set; }
        public virtual ICollection<userskill> userskills { get; set; }
    }
}
