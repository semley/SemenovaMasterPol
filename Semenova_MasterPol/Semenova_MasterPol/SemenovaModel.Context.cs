﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Semenova_MasterPol
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Semenova_МастерПолEntities : DbContext
    {
        private static Semenova_МастерПолEntities _context;
        public static Semenova_МастерПолEntities GetContext()
        {
            if (_context == null)
                _context = new Semenova_МастерПолEntities();
            return _context;
        }
        public Semenova_МастерПолEntities()
            : base("name=Semenova_МастерПолEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<MaterialCountHistory> MaterialCountHistory { get; set; }
        public virtual DbSet<MaterialProduct> MaterialProduct { get; set; }
        public virtual DbSet<MaterialType> MaterialType { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<Partner_Type1> Partner_Type { get; set; }
        public virtual DbSet<PartnerProduct> PartnerProduct { get; set; }
        public virtual DbSet<PartnerSalesHistory> PartnerSalesHistory { get; set; }
        public virtual DbSet<Postavshchik> Postavshchik { get; set; }
        public virtual DbSet<PostavshchikMaterialHistory> PostavshchikMaterialHistory { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Product_Type> Product_Type { get; set; }
        public virtual DbSet<Sotrudnik> Sotrudnik { get; set; }
    }
}
