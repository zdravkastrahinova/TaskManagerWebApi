using System.Data.Entity;
using TaskManagerWebApi.Models;

namespace TaskManagerWebApi.Repositories
{
    public class AppContext:DbContext
    {
        public AppContext() : base("TMApiDB") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public DbSet<Note> Notes { get; set; }
    }
}