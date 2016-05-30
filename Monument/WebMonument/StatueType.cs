namespace WebMonument
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatueType")]
    public partial class StatueType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatueType_id { get; set; }

        public bool? Skulptur { get; set; }

        public bool? Sokkel { get; set; }

        public bool? Relief { get; set; }

        public bool? Springvand { get; set; }

        public int? FK_Statue_id { get; set; }

        public virtual Statuer Statuer { get; set; }
    }
}
