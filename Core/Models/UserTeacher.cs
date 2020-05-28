using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class UserTeacher : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Post> Posts { get; set; } 
        public List<Classroom> Classrooms { get; set; }
    }
}
