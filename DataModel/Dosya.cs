namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dosya")]
    public partial class Dosya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dosya()
        {
            DuyuruDosya = new HashSet<DuyuruDosya>();
        }

        [Key]
        public int No { get; set; }

        public double? Boyut { get; set; }

        [Required]
        [StringLength(50)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Uzantı { get; set; }

        [Required]
        [StringLength(50)]
        public string Adres { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }

        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SonErisimTarihi { get; set; }

        public bool? AktifMi { get; set; }

        public int? ErisimSayisi { get; set; }

        public int? DuyuruNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DuyuruDosya> DuyuruDosya { get; set; }
    }
}
