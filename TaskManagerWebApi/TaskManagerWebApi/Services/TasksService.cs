using System.Collections.Generic;
using System.Linq;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Repositories;

namespace TaskManagerWebApi.Services
{
    public class TasksService : BaseService<Task>
    {
        public TasksService() : base() { }

        public IEnumerable<Note> GetByTaskID(int taskID)
        {
            return  new NotesRepository().GetAll().Where(t => t.TaskID == taskID);
        }
    }
}