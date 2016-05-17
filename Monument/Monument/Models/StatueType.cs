namespace Monument
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("StatuerType")]
    public partial class StatuerType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatuerType_id { get; set; }

        public bool? Skulptur { get; set; }

        public bool? Sokkel { get; set; }

        public bool? Relief { get; set; }

        public bool? Springvand { get; set; }

        public int? FK_Statue_Id { get; set; }

        public virtual Statuer Statuer { get; set; }
    }
}
