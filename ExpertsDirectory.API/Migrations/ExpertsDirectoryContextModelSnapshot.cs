﻿// <auto-generated />
using ExpertDirectory.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExpertsDirectory.API.Migrations
{
    [DbContext(typeof(ExpertsDirectoryContext))]
    partial class ExpertsDirectoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExpertDirectory.API.Models.Member", b =>
                {
                    b.Property<long>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            MemberId = 1L,
                            Email = "waqas.haneef1@gmail.com",
                            Name = "Waqas haneef",
                            Website = "www.waqashaneef.com"
                        },
                        new
                        {
                            MemberId = 2L,
                            Email = "waqas.haneef1@hotmail.com",
                            Name = "Waqas haneef",
                            Website = "www.waqashaneef1.com"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}