using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using InfinityPrints.Models;

namespace InfinityPrints.Models
{
    public class tbl_contentMap : EntityTypeConfiguration<tbl_contentModel>
    {
        public tbl_contentMap()
        {
            HasKey(i => i.ContID);
            ToTable("tbl_content");
        }
    }
}