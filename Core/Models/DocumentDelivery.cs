using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class DocumentDelivery : BaseEntity
    {
        public string Name { get; set; }
        public string Format { get; set; }
        public string Path { get; set; }
        public Delivery Delivery { get; set; }
        public UserStudent Student { get; set; }
    }
}
