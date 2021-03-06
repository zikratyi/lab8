﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity_Framework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class zikratiy_dbEntities : DbContext
    {
        public zikratiy_dbEntities()
            : base("name=zikratiy_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Client_firm> Client_firm { get; set; }
        public virtual DbSet<Client_log> Client_log { get; set; }
        public virtual DbSet<List_software> List_software { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Personal_info> Personal_info { get; set; }
        public virtual DbSet<Price_software> Price_software { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<View_Client> View_Client { get; set; }
        public virtual DbSet<View_Client_firm> View_Client_firm { get; set; }
        public virtual DbSet<View_Manager> View_Manager { get; set; }
    
        public virtual int CheckLastName()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CheckLastName");
        }
    
        public virtual int DeleteClient(Nullable<int> iD_client)
        {
            var iD_clientParameter = iD_client.HasValue ?
                new ObjectParameter("ID_client", iD_client) :
                new ObjectParameter("ID_client", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteClient", iD_clientParameter);
        }
    
        public virtual int InsertClient(string last_name, string first_name, string phone, string email, string city, string street, string number_house, Nullable<int> number_flat, ObjectParameter iD_client, ObjectParameter iD_address, ObjectParameter iD_personal_info)
        {
            var last_nameParameter = last_name != null ?
                new ObjectParameter("last_name", last_name) :
                new ObjectParameter("last_name", typeof(string));
    
            var first_nameParameter = first_name != null ?
                new ObjectParameter("first_name", first_name) :
                new ObjectParameter("first_name", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("city", city) :
                new ObjectParameter("city", typeof(string));
    
            var streetParameter = street != null ?
                new ObjectParameter("street", street) :
                new ObjectParameter("street", typeof(string));
    
            var number_houseParameter = number_house != null ?
                new ObjectParameter("number_house", number_house) :
                new ObjectParameter("number_house", typeof(string));
    
            var number_flatParameter = number_flat.HasValue ?
                new ObjectParameter("number_flat", number_flat) :
                new ObjectParameter("number_flat", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertClient", last_nameParameter, first_nameParameter, phoneParameter, emailParameter, cityParameter, streetParameter, number_houseParameter, number_flatParameter, iD_client, iD_address, iD_personal_info);
        }
    
        public virtual ObjectResult<Nullable<int>> Orders(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Orders", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> OrdersCorporative()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("OrdersCorporative");
        }
    
        public virtual ObjectResult<RaitingSoftware_Result> RaitingSoftware()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RaitingSoftware_Result>("RaitingSoftware");
        }
    
        public virtual ObjectResult<RequestManager_Result> RequestManager()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RequestManager_Result>("RequestManager");
        }
    
        public virtual ObjectResult<TopManagerForMonth_Result> TopManagerForMonth(Nullable<int> month, Nullable<int> year)
        {
            var monthParameter = month.HasValue ?
                new ObjectParameter("month", month) :
                new ObjectParameter("month", typeof(int));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("year", year) :
                new ObjectParameter("year", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TopManagerForMonth_Result>("TopManagerForMonth", monthParameter, yearParameter);
        }
    
        public virtual ObjectResult<TopManagerForYear_Result> TopManagerForYear(Nullable<int> year)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("year", year) :
                new ObjectParameter("year", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TopManagerForYear_Result>("TopManagerForYear", yearParameter);
        }
    
        public virtual ObjectResult<TopManagerLastMonth_Result> TopManagerLastMonth()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TopManagerLastMonth_Result>("TopManagerLastMonth");
        }
    
        public virtual int UpdateClient(Nullable<int> iD_client, string last_name, string first_name, string phone, string email, string city, string street, string number_house, Nullable<int> number_flat)
        {
            var iD_clientParameter = iD_client.HasValue ?
                new ObjectParameter("ID_client", iD_client) :
                new ObjectParameter("ID_client", typeof(int));
    
            var last_nameParameter = last_name != null ?
                new ObjectParameter("last_name", last_name) :
                new ObjectParameter("last_name", typeof(string));
    
            var first_nameParameter = first_name != null ?
                new ObjectParameter("first_name", first_name) :
                new ObjectParameter("first_name", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("city", city) :
                new ObjectParameter("city", typeof(string));
    
            var streetParameter = street != null ?
                new ObjectParameter("street", street) :
                new ObjectParameter("street", typeof(string));
    
            var number_houseParameter = number_house != null ?
                new ObjectParameter("number_house", number_house) :
                new ObjectParameter("number_house", typeof(string));
    
            var number_flatParameter = number_flat.HasValue ?
                new ObjectParameter("number_flat", number_flat) :
                new ObjectParameter("number_flat", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateClient", iD_clientParameter, last_nameParameter, first_nameParameter, phoneParameter, emailParameter, cityParameter, streetParameter, number_houseParameter, number_flatParameter);
        }
    
        public virtual ObjectResult<ViewClients_Result> ViewClients()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ViewClients_Result>("ViewClients");
        }
    }
}
