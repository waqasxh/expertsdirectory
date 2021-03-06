// <auto-generated />
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
                            Name = "Waqas Haneef",
                            Website = "www.waqashaneef.com"
                        },
                        new
                        {
                            Id = 2L,
                            Email = "chadeelahmed@gmail.com",
                            Name = "Adeel Ahmed",
                            Website = "www.adeelahmed.com"
                        });
                });

            modelBuilder.Entity("ExpertDirectory.API.Models.MemberFriend", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("FriendId")
                        .HasColumnType("bigint");

                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("MemberFriend");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            FriendId = 2L,
                            MemberId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            FriendId = 1L,
                            MemberId = 2L
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
                            Text = "Web Programing"
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
                        },
                        new
                        {
                            Id = 4L,
                            MemberId = 2L,
                            Text = "Back-end Programing"
                        },
                        new
                        {
                            Id = 5L,
                            MemberId = 2L,
                            Text = "Software Solutions"
                        });
                });

            modelBuilder.Entity("ExpertDirectory.API.Models.MemberFriend", b =>
                {
                    b.HasOne("ExpertDirectory.API.Models.Member", "Member")
                        .WithMany("MemberFriends")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
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
                    b.Navigation("MemberFriends");

                    b.Navigation("MemberHeaders");
                });
#pragma warning restore 612, 618
        }
    }
}
