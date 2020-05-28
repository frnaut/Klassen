using Core.AppContext;
using Core.IRepository;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class DeliveryRepository : Methods<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
