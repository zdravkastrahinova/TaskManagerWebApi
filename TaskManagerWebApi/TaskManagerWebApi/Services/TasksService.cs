using System.Collections.Generic;
using System.Linq;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Repositories;

namespace TaskManagerWebApi.Services
{
    public class TasksService : BaseService<Task>
    {
        public TasksService() : base() { }

        public IEnumerable<Task> GetByUserID(int userID)
        {
            return new TasksRepository().GetAll().Where(t => t.UserID == userID);
        }
    }
}