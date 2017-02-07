namespace TaskManagerWebApi.Models
{
    public class Task : BaseModel
    {
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}