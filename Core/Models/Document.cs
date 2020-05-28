using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Document : BaseEntity
    {
        public string Name { get; set; }
        public string Format { get; set; }
        public string Path { get; set; }
        public Assignment Assignment { get; set; }
    }
}
