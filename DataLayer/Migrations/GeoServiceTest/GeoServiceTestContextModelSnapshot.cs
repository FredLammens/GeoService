﻿// <auto-generated />
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations.GeoServiceTest
{
    [DbContext(typeof(GeoServiceTestContext))]
    partial class GeoServiceTestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DataLayer.BaseClasses.CountryRiver", b =>
                {
                    b.Property<long>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<long>("RiverId")
                        .HasColumnType("bigint");

                    b.HasKey("CountryId", "RiverId");

                    b.HasIndex("RiverId");

                    b.ToTable("CountryRiver");
                });

            modelBuilder.Entity("DataLayer.BaseClasses.DContinent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Population")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.ToTable("Continents");
                });

            modelBuilder.Entity("DataLayer.BaseClasses.DCountry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

                    b.Property<long>("ContinentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Population")
                        .HasColumnType("bigint");

                    b.Property<float>("Surface")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ContinentId");

                    b.ToTable("DCountry");
                });

            modelBuilder.Entity("DataLayer.BaseClasses.DRiver", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rivers");
                });

            modelBuilder.Entity("DataLayer.BaseClasses.CountryRiver", b =>
                {
                    b.HasOne("DataLayer.BaseClasses.DCountry", "Country")
                        .WithMany("Rivers")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.BaseClasses.DRiver", "River")
                        .WithMany("Countries")
                        .HasForeignKey("RiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("River");
                });

            modelBuilder.Entity("DataLayer.BaseClasses.DCountry", b =>
                {
                    b.HasOne("DataLayer.BaseClasses.DContinent", "Continent")
                        .WithMany("Countries")
                        .HasForeignKey("ContinentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Continent");
                });

            modelBuilder.Entity("DataLayer.BaseClasses.DContinent", b =>
                {
                    b.Navigation("Countries");
                });

            modelBuilder.Entity("DataLayer.BaseClasses.DCountry", b =>
                {
                    b.Navigation("Rivers");
                });

            modelBuilder.Entity("DataLayer.BaseClasses.DRiver", b =>
                {
                    b.Navigation("Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
