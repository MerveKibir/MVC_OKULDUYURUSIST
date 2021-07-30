namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DuyuruGonderim")]
    public partial class DuyuruGonderim
    {
        [Key]
        public int No { get; set; }

        public int? DuyuruNo { get; set; }

        public int? EpostaNo { get; set; }

        [Required]
        [StringLength(50)]
        public string EpostaAdres { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }

        public int? KullaniciNo { get; set; }

        public virtual Duyuru Duyuru { get; set; }
    }
}
