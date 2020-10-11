using DoctorsOffice.Core.Models;
using Microsoft.EntityFrameworkCore; 

namespace DoctorsOffice.Data.Context
{
    public class DoctorsOfficeContext : DbContext
    {
        public DoctorsOfficeContext(DbContextOptions<DoctorsOfficeContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalAppointment> MedicalAppointments { get; set; }
    }
}
