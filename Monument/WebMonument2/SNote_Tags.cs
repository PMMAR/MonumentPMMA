namespace WebMonument2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SNote_Tags
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_StatueNote_id { get; set; }

        public int? FK_Tag_id { get; set; }

        public virtual StatueNoter StatueNoter { get; set; }

        public virtual Tags Tags { get; set; }
    }
}
