namespace Monument
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class SNote_Tags
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_StatuerNote_id { get; set; }

        public int? FK_Tag_id { get; set; }

        public virtual StatuerNoter StatuerNoter { get; set; }

        public virtual Tags Tags { get; set; }
    }
}
