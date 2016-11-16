using System;
using System.Collections.Generic;

namespace HRSmart.Domain.Entities
{
    public partial class userskill
    {
        public userskill()
        {
            this.certificats = new List<certificat>();
        }

        public int level { get; set; }
        public int user_id { get; set; }
        public int skill_id { get; set; }
        public virtual skill skill { get; set; }
        public virtual user user { get; set; }
        public virtual ICollection<certificat> certificats { get; set; }
    }
}
