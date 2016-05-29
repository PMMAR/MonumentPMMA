namespace WebMonument
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Behandlingstyper")]
    public partial class Behandlingstyper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Behandlingstyper()
        {
            StatueBehandling = new HashSet<StatueBehandling>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Behandlingstype_id { get; set; }

        [Column("Behandlingstyper")]
        [StringLength(20)]
        public string Behandlingstyper1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatueBehandling> StatueBehandling { get; set; }
    }
}
