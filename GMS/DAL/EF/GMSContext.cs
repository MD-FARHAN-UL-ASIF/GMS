using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class GMSContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Attendance> Attendences { get; set; }
        public DbSet<Leave>  Leaves { get; set; }

    }
}
