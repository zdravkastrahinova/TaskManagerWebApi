using System;
using System.Data.Entity.Migrations;

namespace TaskManagerWebApi.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Repositories.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Repositories.AppContext context)
        {
            context.Users.AddOrUpdate(u => u.Email,
               new Models.User
               {
                   Name = "Admin Adminov",
                   Email = "admin@mail.bg",
                   Password = "adminpass",
                   DateCreated = DateTime.Now,
                   DateUpdated = DateTime.Now,
                   IsDeleted = false
               });
        }
    }
}
