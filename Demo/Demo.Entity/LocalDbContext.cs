using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Demo.Entity
{
    public partial class LocalDbContext : DbContext
    {
        public LocalDbContext()
        {
        }

        public LocalDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<FabricTest> FabricTest { get; set; }
        public virtual DbSet<FabricTestResultTo> FabricTestResult { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=VNLAP01\\HNOIT;Database=Demo_Test;user id=sa;password=4W&[SRz75uhY'4GU;MultipleActiveResultSets=True;TrustServerCertificate=True;Encrypt=False", b => b.MigrationsAssembly("Demo"));
        }
    }
}
