using System.Collections.Generic;
using System.Linq;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Repositories;

namespace TaskManagerWebApi.Services
{
    public class NotesService : BaseService<Note>
    {
        public NotesService() : base() { }

        public IEnumerable<Note> GetByTaskID(int taskID)
        {
            return new NotesRepository().GetAll().Where(t => t.TaskID == taskID);
        }
    }
}