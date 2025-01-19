using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace InfinityPrints.Models
{
    public class tbl_sizesMap : EntityTypeConfiguration<tbl_sizesModel>
    {
        public tbl_sizesMap()
        {
            HasKey(i => i.SizeID);
            ToTable("tbl_sizes");
        }
    }
}