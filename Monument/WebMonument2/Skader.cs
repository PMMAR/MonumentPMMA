namespace WebMonument2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Skader")]
    public partial class Skader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Skader()
        {
            SkadeNoter = new HashSet<SkadeNoter>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Skade_id { get; set; }

        [StringLength(50)]
        public string SkadeType { get; set; }

        [StringLength(1)]
        public string SkadeGrad { get; set; }

        public int? FK_Statue_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SkadeNoter> SkadeNoter { get; set; }

        public virtual Statuer Statuer { get; set; }
    }
}
