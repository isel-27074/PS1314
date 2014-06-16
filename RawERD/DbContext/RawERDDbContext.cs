using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using RawERD.Data;

namespace RawERD
{
    public class RawERDDbContext<TUser> : DbContext where TUser : User
    {
        //public RawERDDbContext();
        //public RawERDDbContext(string nameOrConnectionString);

        //public virtual IDbSet<Role> Roles { get; set; }
        //public virtual IDbSet<TUser> Users { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder);
        //protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items);
    
    }
}