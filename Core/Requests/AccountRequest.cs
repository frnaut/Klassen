using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Requests
{
    public class AccountRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int AssignmentId { get; set; }
    }
}
