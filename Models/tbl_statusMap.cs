
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace InfinityPrints.Models
{
    public class tbl_statusMap : EntityTypeConfiguration<tbl_statusModel>
    {
        public tbl_statusMap()
        {
            HasKey(i => i.StatID);
            ToTable("tbl_status");
        }
    }
}