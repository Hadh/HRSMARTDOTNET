using HRSmart.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HRSmart.data.Models.Mapping
{
    public class certificatMap : EntityTypeConfiguration<certificat>
    {
        public certificatMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("certificat", "mysqlpi");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.skill_id).HasColumnName("skill_id");

            // Relationships
            this.HasOptional(t => t.skill)
                .WithMany(t => t.certificats)
                .HasForeignKey(d => d.skill_id);

        }
    }
}
