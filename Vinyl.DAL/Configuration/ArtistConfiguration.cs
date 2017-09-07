﻿using System.Data.Entity.ModelConfiguration;
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

            this.Property(t => t.FirstMidName)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            this.Property(t => t.LastName)
                .HasColumnType("varchar")
                .HasMaxLength(200)
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
