using System;
using System.Collections.Generic;

namespace HRSmart.Domain.Entities
{
    public partial class jobskill
    {
        public bool hasQuiz { get; set; }
        public int level { get; set; }
        public int skill_id { get; set; }
        public int jobOffer_id { get; set; }
        public virtual joboffer joboffer { get; set; }
        public virtual skill skill { get; set; }
    }
}
