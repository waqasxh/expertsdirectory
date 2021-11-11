using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertDirectory.API.Models
{
    public class ExpertsDirectoryContext : DbContext
    {
        public ExpertsDirectoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberHeader> MemberHeader { get; set; }

        public DbSet<MemberFriend> MemberFriend { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasData(new Member
            {
                Id = 1,
                Name = "Waqas Haneef",
                Website = "http://www.waqashaneef.com/",
                Email = "waqas.haneef1@gmail.com"                
            });

            modelBuilder.Entity<Member>().HasData(new Member
            {
                Id = 2,
                Name = "Adeel Ahmed",
                Website = "http://www.adeelahmed.com/",
                Email = "chadeelahmed@gmail.com"
            });

            modelBuilder.Entity<MemberHeader>().HasData(new MemberHeader
            {
                Id = 1,
                Text = "Web Programing",
                MemberId = 1
            });

            modelBuilder.Entity<MemberHeader>().HasData(new MemberHeader
            {
                Id = 2,
                Text = "Software Solutions",
                MemberId = 1
            });

            modelBuilder.Entity<MemberHeader>().HasData(new MemberHeader
            {
                Id = 3,
                Text = "Cloud Soultions",
                MemberId = 1
            });

            modelBuilder.Entity<MemberHeader>().HasData(new MemberHeader
            {
                Id = 4,
                Text = "Back-end Programing",
                MemberId = 2
            });

            modelBuilder.Entity<MemberHeader>().HasData(new MemberHeader
            {
                Id = 5,
                Text = "Software Solutions",
                MemberId = 2
            });

            modelBuilder.Entity<MemberFriend>().HasData(new MemberFriend
            {
                Id = 1,
                MemberId = 1,
                FriendId = 2
            });

            modelBuilder.Entity<MemberFriend>().HasData(new MemberFriend
            {
                Id = 2,
                MemberId = 2,
                FriendId = 1
            });
        }
    }
}
