﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Theke.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class thekeEntities : DbContext
    {
        public thekeEntities()
            : base("name=thekeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AgeRating> AgeRating { get; set; }
        public virtual DbSet<BarTable> BarTable { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<DeliverySlip> DeliverySlip { get; set; }
        public virtual DbSet<NutriantContent> NutriantContent { get; set; }
        public virtual DbSet<OrderPosition> OrderPosition { get; set; }
        public virtual DbSet<PriceHistory> PriceHistory { get; set; }
        public virtual DbSet<Producer> Producer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductUnit> ProductUnit { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Waiter> Waiter { get; set; }
        public virtual DbSet<ZipCode> ZipCode { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceAddress> InvoiceAddress { get; set; }
        public virtual DbSet<InvoicePosition> InvoicePosition { get; set; }
        public virtual DbSet<BarOrder> BarOrders { get; set; }
    }
}
