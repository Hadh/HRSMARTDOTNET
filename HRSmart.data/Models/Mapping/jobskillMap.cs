using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HRSmart.Domain.Entities;

namespace HRSmart.data.Models.Mapping
{
    public class jobskillMap : EntityTypeConfiguration<jobskill>
    {
        public jobskillMap()
        {
            // Primary Key
            this.HasKey(t => new { t.skill_id, t.jobOffer_id });

            // Properties
            this.Property(t => t.skill_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.jobOffer_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("jobskill", "mysqlpi");
            this.Property(t => t.hasQuiz).HasColumnName("hasQuiz");
            this.Property(t => t.level).HasColumnName("level");
            this.Property(t => t.skill_id).HasColumnName("skill_id");
            this.Property(t => t.jobOffer_id).HasColumnName("jobOffer_id");

            // Relationships
            this.HasRequired(t => t.joboffer)
                .WithMany(t => t.jobskills)
                .HasForeignKey(d => d.jobOffer_id);
            this.HasRequired(t => t.skill)
                .WithMany(t => t.jobskills)
                .HasForeignKey(d => d.skill_id);

        }
    }
}
