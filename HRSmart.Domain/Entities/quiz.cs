using System;
using System.Collections.Generic;

namespace HRSmart.Domain.Entities
{
    public partial class quiz
    {
        public quiz()
        {
            this.assessments = new List<assessment>();
            this.questions = new List<question>();
        }

        public int id { get; set; }
        public string description { get; set; }
        public int duration { get; set; }
        public float result { get; set; }
        public virtual ICollection<assessment> assessments { get; set; }
        public virtual ICollection<question> questions { get; set; }
    }
}
