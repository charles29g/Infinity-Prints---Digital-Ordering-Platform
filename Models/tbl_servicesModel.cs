using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfinityPrints.Models
{
    public class tbl_servicesModel
    {
        public int ServiceID { get; set; }
        public string ImagePath { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}