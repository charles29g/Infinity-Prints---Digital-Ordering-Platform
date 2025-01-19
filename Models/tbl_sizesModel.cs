using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfinityPrints.Models
{
    public class tbl_sizesModel
    {
        public int SizeID { get; set; }
        public int ServiceID { get; set; }
        public string SizeName { get; set; }
        public float Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}