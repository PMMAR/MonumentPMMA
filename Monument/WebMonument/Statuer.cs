namespace WebMonument
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Statuer")]
    public partial class Statuer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Statuer()
        {
            Materialer = new HashSet<Materialer>();
            Skader = new HashSet<Skader>();
            StatueNoter = new HashSet<StatueNoter>();
            StatuePlacering = new HashSet<StatuePlacering>();
            StatueType = new HashSet<StatueType>();
        }

        [Key]
        public int Statue_id { get; set; }

        [StringLength(50)]
        public string Navn { get; set; }

        public int? FK_PostNr { get; set; }

        [StringLength(1)]
        public string Prioritet { get; set; }

        public virtual Adresse Adresse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Materialer> Materialer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skader> Skader { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatueNoter> StatueNoter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatuePlacering> StatuePlacering { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatueType> StatueType { get; set; }
    }
}
