namespace WebMonument2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatuePlacering")]
    public partial class StatuePlacering
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatuePlacering_id { get; set; }

        public bool? Jord { get; set; }

        public bool? Bygning { get; set; }

        public bool? Facade { get; set; }

        public int? FK_Statue_id { get; set; }

        public virtual Statuer Statuer { get; set; }
    }
}
