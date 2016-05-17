namespace Monument
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Materialer")]
    public partial class Materialer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Materiale_id { get; set; }

        public int? FK_Statue_Id { get; set; }

        public bool? Sandsten { get; set; }

        public bool? Kalksten { get; set; }

        public bool? Marmor { get; set; }

        public bool? Granit { get; set; }

        public bool? Bronze { get; set; }

        public bool? CortenStaal { get; set; }

        public bool? MaletStaal { get; set; }

        public bool? Aluminium { get; set; }

        public bool? Trae { get; set; }

        public bool? Mursten { get; set; }

        public bool? Beton { get; set; }

        public bool? Anden_Stentype { get; set; }

        public bool? Anden_Metaltype { get; set; }

        public bool? Anden_Materialetype { get; set; }

        public virtual Statuer Statuer { get; set; }
    }
}
