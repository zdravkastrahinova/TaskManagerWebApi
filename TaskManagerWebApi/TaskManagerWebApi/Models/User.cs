using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerWebApi.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}