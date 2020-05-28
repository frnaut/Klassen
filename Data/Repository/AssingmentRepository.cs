using Core.AppContext;
using Core.IRepository;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class AssingmentRepository : Methods<Assignment>, IAssignmentsRepository
    {
        public AssingmentRepository(ApplicationContext context) : base(context)
        {
        }

    }
}
