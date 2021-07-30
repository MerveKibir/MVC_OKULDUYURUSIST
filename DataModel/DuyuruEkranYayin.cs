namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DuyuruEkranYayin")]
    public partial class DuyuruEkranYayin
    {
        [Key]
        public int No { get; set; }

        public int? DuyuruNo { get; set; }

        public int? EkranNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }

        public virtual Duyuru Duyuru { get; set; }

        public virtual Ekran Ekran { get; set; }
    }
}
