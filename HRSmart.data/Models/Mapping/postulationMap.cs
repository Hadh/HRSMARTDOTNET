using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HRSmart.Domain.Entities;

namespace HRSmart.data.Models.Mapping
{
    public class postulationMap : EntityTypeConfiguration<postulation>
    {
        public postulationMap()
        {
            // Primary Key
            this.HasKey(t => t.idPostulation);

            // Properties
            // Table & Column Mappings
            this.ToTable("postulation", "mysqlpi");
            this.Property(t => t.idPostulation).HasColumnName("idPostulation");
            this.Property(t => t.datePostulation).HasColumnName("datePostulation");
            this.Property(t => t.postulant_id).HasColumnName("postulant_id");
            this.Property(t => t.reward_jobOffer_id).HasColumnName("reward_jobOffer_id");
            this.Property(t => t.reward_stage_id).HasColumnName("reward_stage_id");

            // Relationships
            this.HasOptional(t => t.reward)
                .WithMany(t => t.postulations)
                .HasForeignKey(d => new { d.reward_jobOffer_id, d.reward_stage_id });
            this.HasOptional(t => t.user)
                .WithMany(t => t.postulations)
                .HasForeignKey(d => d.postulant_id);

        }
    }
}
