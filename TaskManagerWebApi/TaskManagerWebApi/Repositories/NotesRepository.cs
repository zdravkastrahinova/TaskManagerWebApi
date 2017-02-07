using System.Collections.Generic;
using System.Linq;
using TaskManagerWebApi.Models;

namespace TaskManagerWebApi.Repositories
{
    public class NotesRepository : BaseRepository<Note>
    {
        public NotesRepository() : base() { }
    }
}