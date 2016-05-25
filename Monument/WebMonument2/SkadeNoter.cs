namespace WebMonument2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SkadeNoter")]
    public partial class SkadeNoter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SkadeNote_id { get; set; }

        [Column(TypeName = "text")]
        public string Note { get; set; }

        [StringLength(50)]
        public string Titel { get; set; }

        public DateTime? Dato { get; set; }

        public int? FK_Skade_id { get; set; }

        public virtual Skader Skader { get; set; }
    }
}
