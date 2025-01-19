using InfinityPrints.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace InfinityPrints.Models
{
    public class tbl_logsMap : EntityTypeConfiguration<tbl_logsModel>
    {
        public tbl_logsMap()
        {
            HasKey(i => i.LogID);
            ToTable("tbl_logs");
        }
    }
}