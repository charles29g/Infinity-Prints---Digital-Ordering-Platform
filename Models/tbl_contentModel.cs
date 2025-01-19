using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfinityPrints.Models
{
    public class tbl_contentModel
    {

        public int ContID { get; set; }
        public string ContName { get; set; }
        public string Desc { get; set; }
        public string IMG_Path { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}