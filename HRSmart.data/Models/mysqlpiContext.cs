using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using HRSmart.data.Models.Mapping;
using HRSmart.Domain.Entities;

namespace HRSmart.data.Models
{
    public partial class mysqlpiContext : DbContext
    {
        static mysqlpiContext()
        {
            Database.SetInitializer<mysqlpiContext>(null);
        }

        public mysqlpiContext()
            : base("Name=mysqlpiContext")
        {
        }

        public DbSet<address> addresses { get; set; }
        public DbSet<assessment> assessments { get; set; }
        public DbSet<buisness> buisnesses { get; set; }
        public DbSet<certificat> certificats { get; set; }
        public DbSet<choice> choices { get; set; }
        public DbSet<joboffer> joboffers { get; set; }
        public DbSet<jobskill> jobskills { get; set; }
        public DbSet<notification> notifications { get; set; }
        public DbSet<postulation> postulations { get; set; }
        public DbSet<question> questions { get; set; }
        public DbSet<quiz> quizs { get; set; }
        public DbSet<reward> rewards { get; set; }
        public DbSet<skill> skills { get; set; }
        public DbSet<stage> stages { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<userbuisness> userbuisnesses { get; set; }
        public DbSet<userskill> userskills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new addressMap());
            modelBuilder.Configurations.Add(new assessmentMap());
            modelBuilder.Configurations.Add(new buisnessMap());
            modelBuilder.Configurations.Add(new certificatMap());
            modelBuilder.Configurations.Add(new choiceMap());
            modelBuilder.Configurations.Add(new jobofferMap());
            modelBuilder.Configurations.Add(new jobskillMap());
            modelBuilder.Configurations.Add(new notificationMap());
            modelBuilder.Configurations.Add(new postulationMap());
            modelBuilder.Configurations.Add(new questionMap());
            modelBuilder.Configurations.Add(new quizMap());
            modelBuilder.Configurations.Add(new rewardMap());
            modelBuilder.Configurations.Add(new skillMap());
            modelBuilder.Configurations.Add(new stageMap());
            modelBuilder.Configurations.Add(new userMap());
            modelBuilder.Configurations.Add(new userbuisnessMap());
            modelBuilder.Configurations.Add(new userskillMap());
        }
    }
}
