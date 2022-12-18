using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EFLab3
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=EF")
        {
        }

        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<empolyee> empolyees { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<department>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<department>()
                .HasMany(e => e.empolyees)
                .WithOptional(e => e.department)
                .HasForeignKey(e => e.deptid);

            modelBuilder.Entity<empolyee>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
