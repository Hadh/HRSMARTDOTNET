using HRSmart.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HRSmart.data.Models.Mapping
{
    public class assessmentMap : EntityTypeConfiguration<assessment>
    {
        public assessmentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.postulation_id, t.quiz_id });

            // Properties
            this.Property(t => t.postulation_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.quiz_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("assessment", "mysqlpi");
            this.Property(t => t.result).HasColumnName("result");
            this.Property(t => t.postulation_id).HasColumnName("postulation_id");
            this.Property(t => t.quiz_id).HasColumnName("quiz_id");

            // Relationships
            this.HasRequired(t => t.postulation)
                .WithMany(t => t.assessments)
                .HasForeignKey(d => d.postulation_id);
            this.HasRequired(t => t.quiz)
                .WithMany(t => t.assessments)
                .HasForeignKey(d => d.quiz_id);

        }
    }
}
