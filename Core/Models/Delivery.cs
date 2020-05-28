using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Delivery : BaseEntity
    {
        public UserStudent Student { get; set; }
        public Assignment Assignment { get; set; }
        public List<DocumentDelivery> Documents { get; set; }
    }
}
