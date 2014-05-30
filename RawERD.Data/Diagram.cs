namespace RawERD.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Diagram")]
    public partial class Diagram
    {
        [Key]
        public int idDiagram { get; set; }

        public int idUser { get; set; }

        [Required]
        [StringLength(45)]
        public string title { get; set; }

        public int privacy { get; set; }

        [Column(TypeName = "text")]
        public string json { get; set; }

        public virtual User User { get; set; }
    }
}
