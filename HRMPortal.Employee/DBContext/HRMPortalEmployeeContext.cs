using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection.Emit;

namespace HRMPortal.Employee.DBContext
{
    public class HRMPortalEmployeeContext : DbContext
    {
        public DbSet<EmployeeDetail> EmployeeDetail { get; set; }
        public DbSet<Address> Addresse { get; set; }
        public DbSet<BankDetail> BankDetail { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<EducationDetail> EducationDetail { get; set; }
        public DbSet<LeaveBalance> LeaveBalance { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<PreviousExprience> PreviousExprience { get; set; }
        public DbSet<Salary> Salary { get; set; }


        public HRMPortalEmployeeContext(DbContextOptions<HRMPortalEmployeeContext> options) : base(options)
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {

            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");

            base.ConfigureConventions(builder);
        }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Salary>()
             .Property(e => e.CreatedAt)
              .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Salary>()
                .Property(e => e.CreatedBy)
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            base.OnModelCreating(modelBuilder);
        }


    }
}
