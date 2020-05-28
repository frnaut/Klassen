using Core.AppContext;
using Core.IRepository;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class ClassroomRepository : Methods<Classroom>, IClassroomRepository
    {
        public ClassroomRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
