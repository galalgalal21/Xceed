using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.DAL.Entities;

namespace Xceed.DAL.Contexts
{
    public class XceedDbContext : IdentityDbContext<AppUser>
    {
        public XceedDbContext()
        {
            
        }
        public XceedDbContext(DbContextOptions<XceedDbContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Line_of_Business> Line_Of_Businesses { get; set; }
        public DbSet<AccountBusinessLines> AccountBusinessLines { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Language_level> Language_Levels { get; set; }
        public DbSet<EmployeeLanguageLevels> EmployeeLanguageLevels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
           
        }


    }
}
