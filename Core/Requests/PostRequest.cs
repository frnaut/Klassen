using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Requests
{
    public class PostRequest
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int ClassroomId { get; set; }
        public string Teacher { get; set; }
    }
}
