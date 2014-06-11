using Microsoft.AspNet.Identity.EntityFramework;
using RawERD.Data;
using System.Data.Entity;

namespace RawERD.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    //public class ApplicationUser : User
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //public class ApplicationDbContext : RawERDDbContext<ApplicationUser>
    {
        //public ApplicationDbContext()
        //    : base("DefaultConnection")
        //{
        //}
        public ApplicationDbContext()
            : base("DataModel")
        {
        }

        //Para ter acesso às minhas tabelas
        /*
        public DbSet<User> _Users { get; set; }
        public DbSet<Role> _Roles { get; set; }
        public DbSet<Diagram> _Diagrams { get; set; }
        */
    }
}