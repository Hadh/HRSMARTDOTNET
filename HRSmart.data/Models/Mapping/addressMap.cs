using HRSmart.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HRSmart.data.Models.Mapping
{
    public class addressMap : EntityTypeConfiguration<address>
    {
        public addressMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.localisation)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("address", "mysqlpi");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.localisation).HasColumnName("localisation");
            this.Property(t => t.x).HasColumnName("x");
            this.Property(t => t.y).HasColumnName("y");
            this.Property(t => t.buisness_id).HasColumnName("buisness_id");

            // Relationships
            this.HasOptional(t => t.buisness)
                .WithMany(t => t.addresses)
                .HasForeignKey(d => d.buisness_id);

        }
    }
}
