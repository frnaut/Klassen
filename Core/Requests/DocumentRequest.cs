using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Requests
{
    public class DocumentRequest
    {
        public string Name { get; set; }
        public string Format { get; set; }
        public string Path { get; set; }
        public string Teacher { get; set; }
        public int AssignamentId { get; set; }
    }
}
