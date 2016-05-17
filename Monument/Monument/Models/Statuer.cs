namespace Monument
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Statuer")]
    public partial class Statuer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Statuer()
        {
            Materialer = new HashSet<Materialer>();
            Skader = new HashSet<Skader>();
            StatuerNoter = new HashSet<StatuerNoter>();
            StatuerPlacering = new HashSet<StatuerPlacering>();
            StatuerType = new HashSet<StatuerType>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Statue_Id { get; set; }

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
        public virtual ICollection<StatuerNoter> StatuerNoter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatuerPlacering> StatuerPlacering { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatuerType> StatuerType { get; set; }
    }
}