using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HRSmart.Domain.Entities;

namespace HRSmart.data.Models.Mapping
{
    public class questionMap : EntityTypeConfiguration<question>
    {
        public questionMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.body)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("question", "mysqlpi");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.body).HasColumnName("body");
            this.Property(t => t.skill_id).HasColumnName("skill_id");

            // Relationships
            this.HasOptional(t => t.skill)
                .WithMany(t => t.questions)
                .HasForeignKey(d => d.skill_id);

        }
    }
}
