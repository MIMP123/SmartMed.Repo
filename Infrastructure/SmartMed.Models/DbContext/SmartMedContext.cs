using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using SmartMed.Models.Models;

namespace SmartMed.Models
{
    public partial class SmartMedContext : DbContext
    {
        #region variables

        private IConfiguration _configuration;

        #endregion

        public SmartMedContext()
        {
        }

        public SmartMedContext(DbContextOptions<SmartMedContext> options, 
                               IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        #region Dbset

        public DbSet<Medication> Medications { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
