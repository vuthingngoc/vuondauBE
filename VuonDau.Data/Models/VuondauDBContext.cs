﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class VuondauDBContext : DbContext
    {
        public VuondauDBContext()
        {
        }

        public VuondauDBContext(DbContextOptions<VuondauDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerGroup> CustomerGroups { get; set; }
        public virtual DbSet<CustomerInGroup> CustomerInGroups { get; set; }
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<Farm> Farms { get; set; }
        public virtual DbSet<FarmPicture> FarmPictures { get; set; }
        public virtual DbSet<FarmType> FarmTypes { get; set; }
        public virtual DbSet<Farmer> Farmers { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Harvest> Harvests { get; set; }
        public virtual DbSet<HarvestSelling> HarvestSellings { get; set; }
        public virtual DbSet<HarvestSellingPrice> HarvestSellingPrices { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductInCart> ProductInCarts { get; set; }
        public virtual DbSet<ProductPicture> ProductPictures { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=VuondauDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.HasIndex(e => e.UserName, "UQ__Admin__66DCF95C06CD04F7")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("endTime");

                entity.Property(e => e.HarvestSellingId).HasColumnName("harvestSellingID");

                entity.Property(e => e.MinOrderAmount).HasColumnName("minOrderAmount");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("startTime");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.HarvestSelling)
                    .WithMany(p => p.Campaigns)
                    .HasForeignKey(d => d.HarvestSellingId)
                    .HasConstraintName("FK__Campaign__harves__4BAC3F29");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Campaigns)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Campaign__orderI__4CA06362");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.CustomerType).HasColumnName("customerType");

                entity.Property(e => e.DateOfCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfCreate");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(200)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .HasMaxLength(200)
                    .HasColumnName("lastName");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasColumnType("text")
                    .HasColumnName("phone");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.CustomerTypeNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CustomerType)
                    .HasConstraintName("FK__Customer__custom__07020F21");
            });

            modelBuilder.Entity<CustomerGroup>(entity =>
            {
                entity.ToTable("CustomerGroup");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.HarvestSellingId).HasColumnName("harvestSellingID");

                entity.Property(e => e.Location)
                    .HasMaxLength(500)
                    .HasColumnName("location");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.HarvestSelling)
                    .WithMany(p => p.CustomerGroups)
                    .HasForeignKey(d => d.HarvestSellingId)
                    .HasConstraintName("FK__CustomerG__harve__52593CB8");
            });

            modelBuilder.Entity<CustomerInGroup>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.CustomerGroupId })
                    .HasName("PK__Customer__740ACCDE5535A963");

                entity.ToTable("CustomerInGroup");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.CustomerGroupId).HasColumnName("customerGroupID");

                entity.Property(e => e.JoinDate)
                    .HasColumnType("datetime")
                    .HasColumnName("joinDate");

                entity.HasOne(d => d.CustomerGroup)
                    .WithMany(p => p.CustomerInGroups)
                    .HasForeignKey(d => d.CustomerGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerI__custo__5812160E");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerInGroups)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerI__custo__571DF1D5");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.ToTable("CustomerType");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Farm>(entity =>
            {
                entity.ToTable("Farm");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address");

                entity.Property(e => e.AreaId).HasColumnName("areaID");

                entity.Property(e => e.DateOfCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfCreate");

                entity.Property(e => e.DateUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateUpdate");

                entity.Property(e => e.Description)
                    .HasMaxLength(2500)
                    .HasColumnName("description");

                entity.Property(e => e.FarmTypeId).HasColumnName("farmTypeID");

                entity.Property(e => e.FarmerId).HasColumnName("farmerID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Farms)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK__Farm__areaID__32E0915F");

                entity.HasOne(d => d.FarmType)
                    .WithMany(p => p.Farms)
                    .HasForeignKey(d => d.FarmTypeId)
                    .HasConstraintName("FK__Farm__farmTypeID__30F848ED");

                entity.HasOne(d => d.Farmer)
                    .WithMany(p => p.Farms)
                    .HasForeignKey(d => d.FarmerId)
                    .HasConstraintName("FK__Farm__farmerID__31EC6D26");
            });

            modelBuilder.Entity<FarmPicture>(entity =>
            {
                entity.ToTable("FarmPicture");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Alt)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("alt");

                entity.Property(e => e.FarmId).HasColumnName("farmID");

                entity.Property(e => e.Src)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("src");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.FarmPictures)
                    .HasForeignKey(d => d.FarmId)
                    .HasConstraintName("FK__FarmPictu__farmI__693CA210");
            });

            modelBuilder.Entity<FarmType>(entity =>
            {
                entity.ToTable("FarmType");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Farmer>(entity =>
            {
                entity.ToTable("Farmer");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.BirthDay)
                    .HasColumnType("date")
                    .HasColumnName("birthDay");

                entity.Property(e => e.DateOfCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfCreate");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(200)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .HasMaxLength(200)
                    .HasColumnName("lastName");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasColumnType("text")
                    .HasColumnName("phone");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateOfCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfCreate");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Feedback__orderI__1273C1CD");
            });

            modelBuilder.Entity<Harvest>(entity =>
            {
                entity.ToTable("Harvest");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasMaxLength(2500)
                    .HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("endDate");

                entity.Property(e => e.FarmId).HasColumnName("farmID");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("startDate");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.Harvests)
                    .HasForeignKey(d => d.FarmId)
                    .HasConstraintName("FK__Harvest__farmID__398D8EEE");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Harvests)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Harvest__product__38996AB5");
            });

            modelBuilder.Entity<HarvestSelling>(entity =>
            {
                entity.ToTable("HarvestSelling");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateOfCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfCreate");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("endDate");

                entity.Property(e => e.HarvestId).HasColumnName("harvestID");

                entity.Property(e => e.MinWeight).HasColumnName("minWeight");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TotalWeight).HasColumnName("totalWeight");

                entity.HasOne(d => d.Harvest)
                    .WithMany(p => p.HarvestSellings)
                    .HasForeignKey(d => d.HarvestId)
                    .HasConstraintName("FK__HarvestSe__harve__3F466844");
            });

            modelBuilder.Entity<HarvestSellingPrice>(entity =>
            {
                entity.ToTable("HarvestSellingPrice");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.HarvestSellingId).HasColumnName("harvestSellingID");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.HarvestSelling)
                    .WithMany(p => p.HarvestSellingPrices)
                    .HasForeignKey(d => d.HarvestSellingId)
                    .HasConstraintName("FK__HarvestSe__harve__5DCAEF64");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.DateOfCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfCreate");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Order__customerI__0CBAE877");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.HarvestsellingId).HasColumnName("harvestsellingID");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.Harvestselling)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.HarvestsellingId)
                    .HasConstraintName("FK__OrderDeta__harve__44FF419A");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderDeta__order__45F365D3");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Method)
                    .HasMaxLength(500)
                    .HasColumnName("method");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DataOfCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("dataOfCreate");

                entity.Property(e => e.Description)
                    .HasMaxLength(2500)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.ProductTypeId).HasColumnName("productTypeID");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .HasConstraintName("FK__Product__product__1CF15040");
            });

            modelBuilder.Entity<ProductInCart>(entity =>
            {
                entity.ToTable("ProductInCart");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreate");

                entity.Property(e => e.HarvestSellingId).HasColumnName("harvestSellingID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ProductInCarts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__ProductIn__custo__00200768");

                entity.HasOne(d => d.HarvestSelling)
                    .WithMany(p => p.ProductInCarts)
                    .HasForeignKey(d => d.HarvestSellingId)
                    .HasConstraintName("FK__ProductIn__harve__01142BA1");
            });

            modelBuilder.Entity<ProductPicture>(entity =>
            {
                entity.ToTable("ProductPicture");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Alt)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("alt");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.Src)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("src");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPictures)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductPi__produ__6383C8BA");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("ProductType");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.PaymentId).HasColumnName("paymentID");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Transacti__order__797309D9");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__Transacti__payme__7A672E12");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.ToTable("Wallet");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Wallets)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Wallet__customer__6EF57B66");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
