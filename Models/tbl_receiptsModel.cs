using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfinityPrints.Models
{
    public class tbl_receiptsModel
    {
        public int ReceiptID { get; set; }
        public int UserID { get; set; }
        public int OrderID { get; set; }

        public string PaymentTerm { get; set; }
        public string Balance { get; set; }
        public int ReferenceNo { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}