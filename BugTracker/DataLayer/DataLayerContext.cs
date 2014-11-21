using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer
{
    public class DataLayerContext : DbContext
    {
        public DataLayerContext() : base("bugTracker") { }

        public DbSet<Bug> Bug { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Priority> Priority { get; set; }
    }
}
