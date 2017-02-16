using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerWebApi.Models
{
    public class Sprint : BaseModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        [NotMapped]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}