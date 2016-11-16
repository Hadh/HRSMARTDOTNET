using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HRSmart.Domain.Entities;

namespace HRSmart.data.Models.Mapping
{
    public class stageMap : EntityTypeConfiguration<stage>
    {
        public stageMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("stage", "mysqlpi");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.buisness_id).HasColumnName("buisness_id");

            // Relationships
            this.HasOptional(t => t.buisness)
                .WithMany(t => t.stages)
                .HasForeignKey(d => d.buisness_id);

        }
    }
}
