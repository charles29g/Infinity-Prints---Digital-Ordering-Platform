using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfinityPrints.Models
{
    public class tbl_logsModel

    {
        public int LogID { get; set; }

        public int UserID { get; set; }
        public string Action { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}