using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Database
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
    }
}
