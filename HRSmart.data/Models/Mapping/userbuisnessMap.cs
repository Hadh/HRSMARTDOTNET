using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HRSmart.Domain.Entities;

namespace HRSmart.data.Models.Mapping
{
    public class userbuisnessMap : EntityTypeConfiguration<userbuisness>
    {
        public userbuisnessMap()
        {
            // Primary Key
            this.HasKey(t => new { t.buisness_id, t.user_id });

            // Properties
            this.Property(t => t.role)
                .HasMaxLength(255);

            this.Property(t => t.buisness_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.user_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("userbuisness", "mysqlpi");
            this.Property(t => t.hireDate).HasColumnName("hireDate");
            this.Property(t => t.role).HasColumnName("role");
            this.Property(t => t.salary).HasColumnName("salary");
            this.Property(t => t.buisness_id).HasColumnName("buisness_id");
            this.Property(t => t.user_id).HasColumnName("user_id");

            // Relationships
            this.HasRequired(t => t.buisness)
                .WithMany(t => t.userbuisnesses)
                .HasForeignKey(d => d.buisness_id);
            this.HasRequired(t => t.user)
                .WithMany(t => t.userbuisnesses)
                .HasForeignKey(d => d.user_id);

        }
    }
}
