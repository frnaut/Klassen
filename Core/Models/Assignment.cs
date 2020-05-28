using System.Collections.Generic;


namespace Core.Models
{
    public class Assignment : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public UserTeacher Teacher { get; set; }
        public Classroom Classroom { get; set; }
        public List<Document> Documents { get; set; }
        public List<Delivery> Delivery { get; set; }

    }
}
