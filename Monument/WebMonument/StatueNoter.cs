namespace WebMonument
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatueNoter")]
    public partial class StatueNoter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatueNote_id { get; set; }

        [Column(TypeName = "text")]
        public string Note { get; set; }

        [StringLength(50)]
        public string Titel { get; set; }

        public DateTime? Dato { get; set; }

        public int? FK_Statue_id { get; set; }

        public virtual SNote_Tags SNote_Tags { get; set; }

        public virtual Statuer Statuer { get; set; }
    }
}
