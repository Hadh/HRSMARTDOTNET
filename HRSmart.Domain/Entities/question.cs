using System;
using System.Collections.Generic;

namespace HRSmart.Domain.Entities
{
    public partial class question
    {
        public question()
        {
            this.choices = new List<choice>();
            this.quizs = new List<quiz>();
        }

        public int id { get; set; }
        public string body { get; set; }
        public Nullable<int> skill_id { get; set; }
        public virtual ICollection<choice> choices { get; set; }
        public virtual skill skill { get; set; }
        public virtual ICollection<quiz> quizs { get; set; }
    }
}
