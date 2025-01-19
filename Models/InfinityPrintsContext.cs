using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using InfinityPrints.Models;



namespace InfinityPrints.Models
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]

    public class InfinityPrintsContext : DbContext
    {
        static InfinityPrintsContext()
        {
            Database.SetInitializer<InfinityPrintsContext>(null);
        }

        public InfinityPrintsContext() : base("Name=db_infinityprints") { }

        public virtual DbSet<tbl_servicesModel> tbl_services { get; set; }
        public virtual DbSet<tbl_usersModel> tbl_users { get; set; }
        public virtual DbSet<tbl_contentModel> tbl_content { get; set; }
        //public virtual DbSet<tbl_discountsModel> tbl_discounts { get; set; }
        public virtual DbSet<tbl_statusModel> tbl_status { get; set; }
        public virtual DbSet<tbl_logsModel> tbl_logs { get; set; }
        public virtual DbSet<tbl_receiptsModel> tbl_receipts { get; set; }
        //public virtual DbSet<tbl_bookingsModel> tbl_bookings { get; set; }
        public virtual DbSet<tbl_sizesModel> tbl_sizes { get; set; }
        public virtual DbSet<tbl_ordersModel> tbl_orders { get; set; }
        public virtual DbSet<tbl_paymentsModel> tbl_payments { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<tbl_employeesModel>().ToTable("tbl_employees");
            //modelBuilder.Entity<tbl_departmentsModel>().ToTable("tbl_departments");

            modelBuilder.Configurations.Add(new tbl_servicesMap());
            modelBuilder.Configurations.Add(new tbl_usersMap());
            modelBuilder.Configurations.Add(new tbl_contentMap());
            //modelBuilder.Configurations.Add(new tbl_discountsMap());
            modelBuilder.Configurations.Add(new tbl_statusMap());
            modelBuilder.Configurations.Add(new tbl_logsMap());
            modelBuilder.Configurations.Add(new tbl_receiptsMap());
            modelBuilder.Configurations.Add(new tbl_sizesMap());
            modelBuilder.Configurations.Add(new tbl_ordersMap());
            modelBuilder.Configurations.Add(new tbl_paymentsMap());

            //modelBuilder.Configurations.Add(new tbl_bookingsMap());
            //  modelBuilder.Configurations.Add(new tbl_departmentsMap());
        }
    }
}