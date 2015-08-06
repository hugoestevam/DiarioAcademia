﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Configurations;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DiarioAuthContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}