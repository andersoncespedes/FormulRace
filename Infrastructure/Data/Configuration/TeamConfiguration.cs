using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("teams");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            builder.HasMany(d => d.Drivers).WithMany(p => p.Teams)
                .UsingEntity<Dictionary<string, object>>(
                    "TeamDriver",
                    r => r.HasOne<Driver>().WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("team_drivers_ibfk_2"),
                    l => l.HasOne<Team>().WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("team_drivers_ibfk_1"),
                    j =>
                    {
                        j.HasKey("TeamId", "DriverId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("team_drivers");
                        j.HasIndex(new[] { "DriverId" }, "driver_id");
                        j.IndexerProperty<int>("TeamId").HasColumnName("team_id");
                        j.IndexerProperty<int>("DriverId").HasColumnName("driver_id");
                    });
        }
    }
}