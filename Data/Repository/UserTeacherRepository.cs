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
    public class UserTeacherRepository : Methods<UserTeacher>, IUserTeacherRepository
    {
        private readonly ApplicationContext _context;

        public UserTeacherRepository(ApplicationContext context) : base(context)
        {
            this._context = context;
        }

        public  async Task<UserTeacher> GetByEmail(string email)
        {
            UserTeacher model = await _context.Set<UserTeacher>().FirstOrDefaultAsync(x => x.Email == email);
            return model;
        }
    }
}
