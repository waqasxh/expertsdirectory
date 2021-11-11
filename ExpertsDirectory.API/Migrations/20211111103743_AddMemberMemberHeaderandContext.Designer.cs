﻿// <auto-generated />
using ExpertDirectory.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExpertsDirectory.API.Migrations
{
    [DbContext(typeof(ExpertsDirectoryContext))]
    [Migration("20211111103743_AddMemberMemberHeaderandContext")]
    partial class AddMemberMemberHeaderandContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExpertDirectory.API.Models.Member", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Email = "waqas.haneef1@gmail.com",
                            Name = "Waqas haneef",
                            Website = "www.waqashaneef.com"
                        });
                });

            modelBuilder.Entity("ExpertDirectory.API.Models.MemberHeader", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("MemberHeader");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            MemberId = 1L,
                            Text = "Web Programming"
                        },
                        new
                        {
                            Id = 2L,
                            MemberId = 1L,
                            Text = "Software Solutions"
                        },
                        new
                        {
                            Id = 3L,
                            MemberId = 1L,
                            Text = "Cloud Soultions"
                        });
                });

            modelBuilder.Entity("ExpertDirectory.API.Models.MemberHeader", b =>
                {
                    b.HasOne("ExpertDirectory.API.Models.Member", "Member")
                        .WithMany("MemberHeaders")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("ExpertDirectory.API.Models.Member", b =>
                {
                    b.Navigation("MemberHeaders");
                });
#pragma warning restore 612, 618
        }
    }
}
