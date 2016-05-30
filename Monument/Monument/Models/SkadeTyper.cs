namespace WebMonument
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SkadeTyper")]
    public partial class SkadeTyper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SkadeTyper()
        {
            Skader = new HashSet<Skader>();
        }

        [Key]
        public int SkadeType_Id { get; set; }

        [Column("SkadeTyper")]
        [StringLength(20)]
        public string SkadeTyper1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skader> Skader { get; set; }
    }
}
