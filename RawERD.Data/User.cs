namespace RawERD.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public User()
        {
            Diagrams = new HashSet<Diagram>();
            Roles = new HashSet<Role>();
        }

        [Key]
        public int idUser { get; set; }

        [Required]
        [StringLength(45)]
        public string username { get; set; }

        [Required]
        [StringLength(45)]
        public string password { get; set; }

        [Required]
        [StringLength(45)]
        public string name { get; set; }

        [Required]
        [StringLength(45)]
        public string email { get; set; }

        [Required]
        [StringLength(45)]
        public string activationCode { get; set; }

        public bool active { get; set; }

        public virtual ICollection<Diagram> Diagrams { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
