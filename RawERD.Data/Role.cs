namespace RawERD.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int idRole { get; set; }

        [Required]
        [StringLength(45)]
        public string name { get; set; }

        public bool active { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}