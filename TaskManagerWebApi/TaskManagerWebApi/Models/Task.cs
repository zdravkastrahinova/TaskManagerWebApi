using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerWebApi.Models
{
    public class Task : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public int? UserID { get; set; }
        public int? SprintID { get; set; }

        [NotMapped]
        public virtual User User { get; set; }

        [NotMapped]
        public virtual Sprint Sprint { get; set; }

        [NotMapped]
        public virtual ICollection<Note> Notes { get; set; }
    }
}