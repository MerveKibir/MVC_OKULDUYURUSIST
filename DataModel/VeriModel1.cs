using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataModel
{
    public partial class VeriModel1 : DbContext
    {
        public VeriModel1()
            : base("name=VeriModel1")
        {
        }

        public virtual DbSet<Log> Log { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>()
                .Property(e => e.Metot)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.Ip)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.Tarayıcı)
                .IsUnicode(false);
        }
    }
}
