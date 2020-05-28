using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Classroom Classroom { get; set; }
        public UserTeacher Teacher { get; set; }
    }
}
