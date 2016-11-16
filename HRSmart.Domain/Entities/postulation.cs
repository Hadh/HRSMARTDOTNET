using System;
using System.Collections.Generic;

namespace HRSmart.Domain.Entities
{
    public partial class postulation
    {
        public postulation()
        {
            this.assessments = new List<assessment>();
        }

        public int idPostulation { get; set; }
        public Nullable<System.DateTime> datePostulation { get; set; }
        public Nullable<int> postulant_id { get; set; }
        public Nullable<int> reward_jobOffer_id { get; set; }
        public Nullable<int> reward_stage_id { get; set; }
        public virtual ICollection<assessment> assessments { get; set; }
        public virtual reward reward { get; set; }
        public virtual user user { get; set; }
    }
}
