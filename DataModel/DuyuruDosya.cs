namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DuyuruDosya")]
    public partial class DuyuruDosya
    {
        [Key]
        public int No { get; set; }

        public int? DosyaNo { get; set; }

        public int? DuyuruNo { get; set; }

        public virtual Dosya Dosya { get; set; }

        public virtual Duyuru Duyuru { get; set; }
    }
}
