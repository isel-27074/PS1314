using Microsoft.AspNet.Identity;

namespace RawERD.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User : IUser
    {
        public User()
        {
            Diagrams = new HashSet<Diagram>();
            Roles = new HashSet<Role>();
        }

        [Key]
        [Column("idUser")]
        public string Id { get; set; }

        [Required]
        [StringLength(45)]
        [Column("username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(45)]
        [Column("password")]
        public string Password { get; set; }

        [Required]
        [StringLength(45)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [StringLength(45)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [StringLength(45)]
        [Column("activationCode")]
        public string ActivationCode { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        public virtual ICollection<Diagram> Diagrams { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
