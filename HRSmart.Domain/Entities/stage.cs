using System;
using System.Collections.Generic;

namespace HRSmart.Domain.Entities
{
    public partial class stage
    {
        public stage()
        {
            this.rewards = new List<reward>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> buisness_id { get; set; }
        public virtual buisness buisness { get; set; }
        public virtual ICollection<reward> rewards { get; set; }
    }
}
