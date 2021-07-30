using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataModel
{
    public partial class VeriModel : DbContext
    {
        public VeriModel()
            : base("name=VeriModel")
        {
        }

        public virtual DbSet<Dosya> Dosya { get; set; }
        public virtual DbSet<Duyuru> Duyuru { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<DuyuruDosya> DuyuruDosya { get; set; }
        public virtual DbSet<DuyuruEkranYayin> DuyuruEkranYayin { get; set; }
        public virtual DbSet<DuyuruGonderim> DuyuruGonderim { get; set; }
        public virtual DbSet<DuyuruTur> DuyuruTur { get; set; }
        public virtual DbSet<Ekran> Ekran { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<menu> menu { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dosya>()
                .Property(e => e.Uzantı)
                .IsUnicode(false);
        }
    }
}
