using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace InfinityPrints.Models
{
    public class tbl_servicesMap : EntityTypeConfiguration<tbl_servicesModel>
    {
        public tbl_servicesMap()
        {
            HasKey(i => i.ServiceID);
            ToTable("tbl_services");
        }
    }
}