using System;
using System.Collections.Generic;

namespace HRSmart.Domain.Entities
{
    public partial class choice
    {
        public int id { get; set; }
        public string body { get; set; }
        public bool correct { get; set; }
        public int mark { get; set; }
        public Nullable<int> question_id { get; set; }
        public virtual question question { get; set; }
    }
}
