using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace InfinityPrints.Models
{
    public class tbl_paymentsMap : EntityTypeConfiguration<tbl_paymentsModel>
    {
        public tbl_paymentsMap()
        {
            HasKey(i => i.PaymentID);
            ToTable("tbl_payments");
        }
    }
}