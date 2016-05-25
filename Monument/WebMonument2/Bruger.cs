namespace WebMonument2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bruger")]
    public partial class Bruger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Bruger_id { get; set; }

        [StringLength(50)]
        public string Brugernavn { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(16)]
        public string Salt { get; set; }

        [StringLength(50)]
        public string Fornavn { get; set; }

        [StringLength(50)]
        public string Efternavn { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}
