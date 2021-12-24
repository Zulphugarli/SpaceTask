using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Request
{
    public class AddUserRequest
    {
        public string Username { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
    }
}
