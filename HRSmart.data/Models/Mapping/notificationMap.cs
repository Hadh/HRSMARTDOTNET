using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HRSmart.Domain.Entities;

namespace HRSmart.data.Models.Mapping
{
    public class notificationMap : EntityTypeConfiguration<notification>
    {
        public notificationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.notificationText)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("notification", "mysqlpi");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.notificationText).HasColumnName("notificationText");
            this.Property(t => t.user_id).HasColumnName("user_id");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.notifications)
                .HasForeignKey(d => d.user_id);

        }
    }
}
