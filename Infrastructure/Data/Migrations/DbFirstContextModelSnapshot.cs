﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(DbFirstContext))]
    partial class DbFirstContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("Core.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("drivers", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("teams", (string)null);
                });

            modelBuilder.Entity("TeamDriver", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int")
                        .HasColumnName("team_id");

                    b.Property<int>("DriverId")
                        .HasColumnType("int")
                        .HasColumnName("driver_id");

                    b.HasKey("TeamId", "DriverId")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "DriverId" }, "driver_id");

                    b.ToTable("team_drivers", (string)null);
                });

            modelBuilder.Entity("TeamDriver", b =>
                {
                    b.HasOne("Core.Entities.Driver", null)
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .IsRequired()
                        .HasConstraintName("team_drivers_ibfk_2");

                    b.HasOne("Core.Entities.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .IsRequired()
                        .HasConstraintName("team_drivers_ibfk_1");
                });
#pragma warning restore 612, 618
        }
    }
}
