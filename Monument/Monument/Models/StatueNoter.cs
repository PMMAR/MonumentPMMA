namespace Monument
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("StatuerNoter")]
    public partial class StatuerNoter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatuerNote_id { get; set; }

        [Column(TypeName = "text")]
        public string Note { get; set; }

        [StringLength(50)]
        public string Titel { get; set; }

        public DateTime? Dato { get; set; }

        public int? FK_Statue_Id { get; set; }

        public virtual SNote_Tags SNote_Tags { get; set; }

        public virtual Statuer Statuer { get; set; }
    }
}
