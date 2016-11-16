using System;
using System.Collections.Generic;

namespace HRSmart.Domain.Entities
{
    public partial class buisness
    {
        public buisness()
        {
            this.addresses = new List<address>();
            this.stages = new List<stage>();
            this.userbuisnesses = new List<userbuisness>();
            this.joboffers = new List<joboffer>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public virtual ICollection<address> addresses { get; set; }
        public virtual ICollection<stage> stages { get; set; }
        public virtual ICollection<userbuisness> userbuisnesses { get; set; }
        public virtual ICollection<joboffer> joboffers { get; set; }
    }
}
