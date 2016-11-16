using System;
using System.Collections.Generic;

namespace HRSmart.Domain.Entities
{
    public partial class joboffer
    {
        public joboffer()
        {
            this.rewards = new List<reward>();
            this.jobskills = new List<jobskill>();
        }

        public int id { get; set; }
        public bool active { get; set; }
        public string description { get; set; }
        public int salary { get; set; }
        public string title { get; set; }
        public Nullable<int> buisness_id { get; set; }
        public virtual buisness buisness { get; set; }
        public virtual ICollection<reward> rewards { get; set; }
        public virtual ICollection<jobskill> jobskills { get; set; }
    }
}
