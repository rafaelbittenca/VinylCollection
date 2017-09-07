using System.Data.Entity.ModelConfiguration;
using Vinyl.Models;

namespace Vinyl.DAL.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.ToTable("User");

            this.HasKey(u => u.ID);

            this.Property(u => u.Email)
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

            this.Property(u => u.Password)
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

            this.Property(p => p.CreatedBy)
                .HasColumnType("varchar")
                .HasMaxLength(150);

            this.Property(p => p.UpdatedBy)
                .HasColumnType("varchar")
                .HasMaxLength(150);
        }
    }
}
