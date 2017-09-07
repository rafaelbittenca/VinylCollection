using System.Data.Entity.ModelConfiguration;
using Vinyl.Models;

namespace Vinyl.DAL.Configuration
{
    public class RecordConfiguration : EntityTypeConfiguration<Record>
    {
        public RecordConfiguration()
        {
            this.ToTable("Record");

            this.HasKey(r => r.ID);

            this.Property(r => r.Title)
                .IsRequired();

            this.Property(r => r.Year)
                .IsRequired();

            this.HasRequired(r => r.Artist)
                .WithMany(a => a.Records)
                .HasForeignKey(r => r.ArtistId)
                .WillCascadeOnDelete(false);

            this.Property(r => r.CreatedBy)
                .HasColumnType("varchar")
                .HasMaxLength(150);

            this.Property(r => r.UpdatedBy)
                .HasColumnType("varchar")
                .HasMaxLength(150);
        }
    }
}
