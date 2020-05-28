using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IUserStudentRepository : IMethods<UserStudent>
    {
        Task<UserStudent> GetByEmail(string email);
    }
}
