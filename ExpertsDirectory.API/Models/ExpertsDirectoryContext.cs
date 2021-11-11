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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasData(new Member
            {
                Id = 1,
                Name = "Waqas haneef",
                Website = "www.waqashaneef.com",
                Email = "waqas.haneef1@gmail.com"                
            });

            modelBuilder.Entity<MemberHeader>().HasData(new MemberHeader
            {
                Id = 1,
                Text = "Web Programming",
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
        }
    }
}
