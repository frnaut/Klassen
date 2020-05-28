using Core.AppContext;
using Core.IRepository;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class RoleRepository : Methods<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
