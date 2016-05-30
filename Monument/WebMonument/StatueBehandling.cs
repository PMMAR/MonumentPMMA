namespace WebMonument
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatueBehandling")]
    public partial class StatueBehandling
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatueBehandling_id { get; set; }

        public int? fk_Behandlingstype_id { get; set; }

        [Column("1st_Behandling", TypeName = "date")]
        public DateTime? C1st_Behandling { get; set; }

        [Column("2nd_Behandling", TypeName = "date")]
        public DateTime? C2nd_Behandling { get; set; }

        [Column("3rd_Behandling", TypeName = "date")]
        public DateTime? C3rd_Behandling { get; set; }

        public int? fk_Statue_id { get; set; }

        public virtual Behandlingstyper Behandlingstyper { get; set; }

        public virtual Statuer Statuer { get; set; }
    }
}
