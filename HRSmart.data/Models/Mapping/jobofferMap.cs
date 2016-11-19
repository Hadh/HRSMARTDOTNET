using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HRSmart.Domain.Entities;

namespace HRSmart.data.Models.Mapping
{
    public class jobofferMap : EntityTypeConfiguration<joboffer>
    {
        public jobofferMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.title)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("joboffer", "mysqlpi");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.active).HasColumnName("active");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.salary).HasColumnName("salary");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.buisness_id).HasColumnName("buisness_id");

            // Relationships
            this.HasOptional(t => t.buisness)
                .WithMany(t => t.Jobs)
                .HasForeignKey(d => d.buisness_id);

        }
    }
}
