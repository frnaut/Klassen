using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Classroom : BaseEntity
    {
        public string Name { get; set; }
        public UserTeacher Teacher { get; set; }
        public List<UserStudent> Students { get; set; }
        public List<Post> Posts { get; set; }
        public List<Assignment> assignments { get; set; }
    }
}
