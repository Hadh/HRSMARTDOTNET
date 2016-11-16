using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HRSmart.Domain.Entities;

namespace HRSmart.data.Models.Mapping
{
    public class userskillMap : EntityTypeConfiguration<userskill>
    {
        public userskillMap()
        {
            // Primary Key
            this.HasKey(t => new { t.user_id, t.skill_id });

            // Properties
            this.Property(t => t.user_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.skill_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("userskill", "mysqlpi");
            this.Property(t => t.level).HasColumnName("level");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.skill_id).HasColumnName("skill_id");

            // Relationships
            this.HasMany(t => t.certificats)
                .WithMany(t => t.userskills)
                .Map(m =>
                    {
                        m.ToTable("userskill_certificat", "mysqlpi");
                        m.MapLeftKey("userSkills_user_id", "userSkills_skill_id");
                        m.MapRightKey("certificats_id");
                    });

            this.HasRequired(t => t.skill)
                .WithMany(t => t.userskills)
                .HasForeignKey(d => d.skill_id);
            this.HasRequired(t => t.user)
                .WithMany(t => t.userskills)
                .HasForeignKey(d => d.user_id);

        }
    }
}
