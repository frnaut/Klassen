using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Requests
{
    public class UsersRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
