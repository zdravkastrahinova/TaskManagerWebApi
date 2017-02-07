namespace TaskManagerWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskManagerWebApi.Repositories.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TaskManagerWebApi.Repositories.AppContext context)
        {
            context.Users.AddOrUpdate(new Models.User
            {
                ID = 1,
                Email = "admin@mail.bg",
                Password = "adminpass",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                IsDeleted = false
            });

            context.Tasks.AddOrUpdate(new Models.Task
            {
                Name = "Create web api app",
                UserID = 1,
                IsComplete = true,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                IsDeleted = false
            });

            context.Notes.AddOrUpdate(new Models.Note
            {
                Title = "Web api app",
                Content = "Create web api app",
                TaskID = 1,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}
