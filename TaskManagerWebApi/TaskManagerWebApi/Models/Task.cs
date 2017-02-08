using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerWebApi.Models
{
    public class Task : BaseModel
    {
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public int UserID { get; set; }

        [NotMapped]
        public virtual User User { get; set; }

        [NotMapped]
        public virtual ICollection<Note> Notes { get; set; }
    }
}