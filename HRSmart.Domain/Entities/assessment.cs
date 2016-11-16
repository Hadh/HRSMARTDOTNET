using System;
using System.Collections.Generic;

namespace HRSmart.Domain.Entities
{
    public partial class assessment
    {
        public int result { get; set; }
        public int postulation_id { get; set; }
        public int quiz_id { get; set; }
        public virtual postulation postulation { get; set; }
        public virtual quiz quiz { get; set; }
    }
}
