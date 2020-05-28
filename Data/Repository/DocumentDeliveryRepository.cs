using Core.AppContext;
using Core.IRepository;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Data.Repository
{
    public class DocumentDeliveryRepository : Methods<DocumentDelivery>, IDocumentDeliveryRepository
    {
        public DocumentDeliveryRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
