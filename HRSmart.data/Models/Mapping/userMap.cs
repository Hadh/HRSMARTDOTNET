using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HRSmart.Domain.Entities;

namespace HRSmart.data.Models.Mapping
{
    public class userMap : EntityTypeConfiguration<user>
    {
        public userMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.adresse)
                .HasMaxLength(255);

            this.Property(t => t.firstName)
                .HasMaxLength(255);

            this.Property(t => t.lastName)
                .HasMaxLength(255);

            this.Property(t => t.login)
                .HasMaxLength(255);

            this.Property(t => t.numTel)
                .HasMaxLength(255);

            this.Property(t => t.password)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("user", "mysqlpi");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.adresse).HasColumnName("adresse");
            this.Property(t => t.age).HasColumnName("age");
            this.Property(t => t.firstName).HasColumnName("firstName");
            this.Property(t => t.lastName).HasColumnName("lastName");
            this.Property(t => t.login).HasColumnName("login");
            this.Property(t => t.numTel).HasColumnName("numTel");
            this.Property(t => t.password).HasColumnName("password");
        }
    }
}
