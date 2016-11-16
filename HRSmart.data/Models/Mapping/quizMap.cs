using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HRSmart.Domain.Entities;

namespace HRSmart.data.Models.Mapping
{
    public class quizMap : EntityTypeConfiguration<quiz>
    {
        public quizMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("quiz", "mysqlpi");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.duration).HasColumnName("duration");
            this.Property(t => t.result).HasColumnName("result");

            // Relationships
            this.HasMany(t => t.questions)
                .WithMany(t => t.quizs)
                .Map(m =>
                    {
                        m.ToTable("quiz_question", "mysqlpi");
                        m.MapLeftKey("quizs_id");
                        m.MapRightKey("questions_id");
                    });


        }
    }
}
