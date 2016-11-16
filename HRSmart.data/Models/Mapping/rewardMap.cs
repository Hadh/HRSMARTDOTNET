using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HRSmart.Domain.Entities;

namespace HRSmart.data.Models.Mapping
{
    public class rewardMap : EntityTypeConfiguration<reward>
    {
        public rewardMap()
        {
            // Primary Key
            this.HasKey(t => new { t.stage_id, t.jobOffer_id });

            // Properties
            this.Property(t => t.stage_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.jobOffer_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("rewards", "mysqlpi");
            this.Property(t => t.value).HasColumnName("value");
            this.Property(t => t.stage_id).HasColumnName("stage_id");
            this.Property(t => t.jobOffer_id).HasColumnName("jobOffer_id");

            // Relationships
            this.HasRequired(t => t.joboffer)
                .WithMany(t => t.rewards)
                .HasForeignKey(d => d.jobOffer_id);
            this.HasRequired(t => t.stage)
                .WithMany(t => t.rewards)
                .HasForeignKey(d => d.stage_id);

        }
    }
}
