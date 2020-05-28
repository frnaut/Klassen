using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IUserTeacherRepository : IMethods<UserTeacher>
    {
        Task<UserTeacher> GetByEmail(string email);
    }
}
