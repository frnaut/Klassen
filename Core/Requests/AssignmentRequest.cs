using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Requests
{
    public class AssignmentRequest
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Teacher { get; set; }
        public int ClassroomId { get; set; }

    }
}
