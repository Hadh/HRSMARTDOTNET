using System;
using System.Collections.Generic;

namespace HRSmart.Domain.Entities
{
    public partial class skill
    {
        public skill()
        {
            this.certificats = new List<certificat>();
            this.jobskills = new List<jobskill>();
            this.questions = new List<question>();
            this.userskills = new List<userskill>();
        }

        public skill(string name, string photo)
        {
            this.name = name;
            this.photo = photo;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
        public virtual ICollection<certificat> certificats { get; set; }
        public virtual ICollection<jobskill> jobskills { get; set; }
        public virtual ICollection<question> questions { get; set; }
        public virtual ICollection<userskill> userskills { get; set; }
    }
}
