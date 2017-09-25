using System.Data.Entity.ModelConfiguration;
using Vinyl.Models;

namespace Vinyl.DAL.Configuration
{
	public class ArtistConfiguration : EntityTypeConfiguration<Artist>
	{
		public ArtistConfiguration()
		{
			this.ToTable("Artist");

			this.HasKey(a => a.ID);

			this.Property(t => t.BirthDate)
			    .IsRequired();

			this.Property(t => t.Name)
			    .HasColumnType("varchar")
                      .HasMaxLength(200)
                      .HasUniqueIndexAnnotation("UQ_Name", 0) // Index Unique - Contraint
                      .IsRequired();

			this.Property(a => a.CreatedBy)
			    .HasColumnType("varchar")
			    .HasMaxLength(150);

			this.Property(a => a.UpdatedBy)
			    .HasColumnType("varchar")
			    .HasMaxLength(150);
		}
	}
}
