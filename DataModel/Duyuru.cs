namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Duyuru")]
    public partial class Duyuru
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Duyuru()
        {
            DuyuruDosya = new HashSet<DuyuruDosya>();
            DuyuruEkranYayin = new HashSet<DuyuruEkranYayin>();
            DuyuruGonderim = new HashSet<DuyuruGonderim>();
        }

        [Key]
        public int No { get; set; }

        [Required]
        [StringLength(50)]
        public string Baslik { get; set; }

        [Required]
        [StringLength(250)]
        public string Metin { get; set; }

        [Required]
        [StringLength(50)]
        public string MetinHtml { get; set; }

        [Required]
        [StringLength(50)]
        public string BaslikHtml { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OlusturmaTarihi { get; set; }

        public int? KullaniciNo { get; set; }

        public int? DuyuruTurNo { get; set; }

        public bool? GonderildiMi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? GondermeTarihi { get; set; }

        public virtual DuyuruTur DuyuruTur { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DuyuruDosya> DuyuruDosya { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DuyuruEkranYayin> DuyuruEkranYayin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DuyuruGonderim> DuyuruGonderim { get; set; }
    }
}
