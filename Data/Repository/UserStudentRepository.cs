using Core.AppContext;
using Core.IRepository;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserStudentRepository : Methods<UserStudent>, IUserStudentRepository
    {
        private readonly ApplicationContext _context;

        public UserStudentRepository(ApplicationContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<UserStudent> GetByEmail(string email)
        {
            UserStudent model = await _context.Set<UserStudent>().FirstOrDefaultAsync(x => x.Email == email);
            return model;
        }
    }
}
