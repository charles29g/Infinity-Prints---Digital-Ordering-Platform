
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace InfinityPrints.Models
{
    public class tbl_ordersMap : EntityTypeConfiguration<tbl_ordersModel>
    {
        public tbl_ordersMap()
        {
            HasKey(i => i.OrderID);
            ToTable("tbl_orders");
        }
    }
}