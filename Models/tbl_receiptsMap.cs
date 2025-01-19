using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace InfinityPrints.Models
{
    public class tbl_receiptsMap : EntityTypeConfiguration<tbl_receiptsModel>
    {
        public tbl_receiptsMap()
        {
            HasKey(i => i.ReceiptID);
            ToTable("tbl_receipts");
        }
    }
}