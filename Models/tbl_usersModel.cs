using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfinityPrints.Models
{
    public class tbl_usersModel
    {
        public int UserID { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }
        public string Email { get; set; }
        public string UName { get; set; }
        public long PhoneNum { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string IsActive { get; set; }
    }
}