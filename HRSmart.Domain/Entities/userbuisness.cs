using System;
using System.Collections.Generic;

namespace HRSmart.Domain.Entities
{
    public partial class userbuisness
    {
        public Nullable<System.DateTime> hireDate { get; set; }
        public string role { get; set; }
        public int salary { get; set; }
        public int buisness_id { get; set; }
        public int user_id { get; set; }
        public virtual buisness buisness { get; set; }
        public virtual user user { get; set; }
    }
}
