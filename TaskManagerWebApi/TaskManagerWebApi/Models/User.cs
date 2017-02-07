using System.Collections.Generic;

namespace TaskManagerWebApi.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}