using System;

namespace TaskManagerWebApi.Models
{
    public class BaseModel
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}