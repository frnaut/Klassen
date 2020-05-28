using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Requests
{
    public class DocumentDeliveryRequest 
    {
        public string Name { get; set; }
        public string Format { get; set; }
        public string Doc { get; set; }
        public string Student { get; set; }
        public int DeliveryId { get; set; }
    }
}
