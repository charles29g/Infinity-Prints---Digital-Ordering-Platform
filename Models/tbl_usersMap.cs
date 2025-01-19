using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using InfinityPrints.Models;

namespace InfinityPrints.Models
{
    public class tbl_usersMap : EntityTypeConfiguration<tbl_usersModel>
    {
        public tbl_usersMap()
        {
            HasKey(i => i.UserID);
            ToTable("tbl_users");
        }
    }
}