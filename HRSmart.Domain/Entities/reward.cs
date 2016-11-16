using System;
using System.Collections.Generic;

namespace HRSmart.Domain.Entities
{
    public partial class reward
    {
        public reward()
        {
            this.postulations = new List<postulation>();
        }

        public int value { get; set; }
        public int stage_id { get; set; }
        public int jobOffer_id { get; set; }
        public virtual joboffer joboffer { get; set; }
        public virtual ICollection<postulation> postulations { get; set; }
        public virtual stage stage { get; set; }
    }
}
