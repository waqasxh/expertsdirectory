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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasData(new Member
            {
                MemberId = 1,
                Name = "Waqas haneef",
                Website = "www.waqashaneef.com",
                Email = "waqas.haneef1@gmail.com",

            }, new Member
            {
                MemberId = 2,
                Name = "Waqas haneef",
                Website = "www.waqashaneef1.com",
                Email = "waqas.haneef1@hotmail.com",
            });
        }
    }
}
