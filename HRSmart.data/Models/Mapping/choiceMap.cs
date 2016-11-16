using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HRSmart.Domain.Entities;

namespace HRSmart.data.Models.Mapping
{
    public class choiceMap : EntityTypeConfiguration<choice>
    {
        public choiceMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.body)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("choice", "mysqlpi");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.body).HasColumnName("body");
            this.Property(t => t.correct).HasColumnName("correct");
            this.Property(t => t.mark).HasColumnName("mark");
            this.Property(t => t.question_id).HasColumnName("question_id");

            // Relationships
            this.HasOptional(t => t.question)
                .WithMany(t => t.choices)
                .HasForeignKey(d => d.question_id);

        }
    }
}
