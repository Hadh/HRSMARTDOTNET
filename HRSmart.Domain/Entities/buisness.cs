using System;
using System.Collections.Generic;

namespace HRSmart.Domain.Entities
{
    public partial class buisness
    {
        public buisness()
        {
            this.Address = new List<address>();
            this.Stages = new List<stage>();
            this.Users = new List<userbuisness>();
            this.Jobs = new List<joboffer>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public bool valid { get; set; }
        public virtual ICollection<address> Address { get; set; }
        public virtual ICollection<stage> Stages { get; set; }
        public virtual ICollection<userbuisness> Users { get; set; }
        public virtual ICollection<joboffer> Jobs { get; set; }
    }
}
