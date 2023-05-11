using CoronaManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaManagement.DAL
{
    public class CoronaDbContext : DbContext
    {
        public DbSet<Patient>  Patient { get; set; }
        public DbSet<CoronaDetails> Vaccinations { get; set; }
        public DbSet<VaccinationDates> VaccinationDates { get; set; }
        public DbSet<VaccinationInfo> VaccinationInfo { get; set; }

        public CoronaDbContext(DbContextOptions<CoronaDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Corona_Managment_System;");
            
        }
    }
}
