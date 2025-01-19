using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfinityPrints.Models
{
    public class tbl_paymentsModel
    {
        public int PaymentID { get; set; }
        public string ReferenceNo { get; set; }
        public string IMG_PayPath { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}