namespace TaskManagerWebApi.Models
{
    public class Note:BaseModel
    {
        public string Title { get; set; }
        public string  Content { get; set; }

        public int TaskID { get; set; }
        public virtual Task Task { get; set; }
    }
}