namespace Monument
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("StatuerPlacering")]
    public partial class StatuerPlacering
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatuerPlacering_id { get; set; }

        public bool? Jord { get; set; }

        public bool? Bygning { get; set; }

        public bool? Facade { get; set; }

        public int? FK_Statue_Id { get; set; }

        public virtual Statuer Statuer { get; set; }
    }
}
