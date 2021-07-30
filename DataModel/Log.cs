namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        [StringLength(50)]
        public string Metot { get; set; }

        [StringLength(50)]
        public string Ip { get; set; }

        [StringLength(50)]
        public string Tarayıcı { get; set; }

        public DateTime? Tarih { get; set; }

        public int Id { get; set; }
    }
}
