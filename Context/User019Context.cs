using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using skiing.Models;

namespace skiing.Context;

public partial class User019Context : DbContext
{
    public User019Context()
    {
    }

    public User019Context(DbContextOptions<User019Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<LoginHistory> LoginHistories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=89.110.53.87:5522;Database=user019;Username=user019;Password=16527");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("clients_pk");

            entity.ToTable("clients", "demo");

            entity.Property(e => e.IdClient)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_client");
            entity.Property(e => e.ClientAdress)
                .HasColumnType("character varying")
                .HasColumnName("client_adress");
            entity.Property(e => e.ClientBirth).HasColumnName("client_birth");
            entity.Property(e => e.ClientCode)
                .HasColumnType("character varying")
                .HasColumnName("client_code");
            entity.Property(e => e.ClientPassportCode)
                .HasColumnType("character varying")
                .HasColumnName("client_passport_code");
            entity.Property(e => e.ClientPassportSeries)
                .HasColumnType("character varying")
                .HasColumnName("client_passport_series");
        });

        modelBuilder.Entity<LoginHistory>(entity =>
        {
            entity.HasKey(e => e.IdLoginHistory).HasName("login_history_pk");

            entity.ToTable("login_history", "demo");

            entity.Property(e => e.IdLoginHistory)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_login_history");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.LoginDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("login_date");
            entity.Property(e => e.Validation).HasColumnName("validation");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.LoginHistories)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("login_history_user_fk");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("order_pk");

            entity.ToTable("order", "demo");

            entity.Property(e => e.IdOrder)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_order");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdOrderStatus).HasColumnName("id_order_status");
            entity.Property(e => e.IdService).HasColumnName("id_service");
            entity.Property(e => e.OrderCode)
                .HasColumnType("character varying")
                .HasColumnName("order_code");
            entity.Property(e => e.OrderDateClose).HasColumnName("order_date_close");
            entity.Property(e => e.OrderRentTime).HasColumnName("order_rent_time");
            entity.Property(e => e.OrderTime).HasColumnName("order_time");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("order_clients_fk");

            entity.HasOne(d => d.IdOrderStatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdOrderStatus)
                .HasConstraintName("order_order_status_fk");

            entity.HasOne(d => d.IdServiceNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdService)
                .HasConstraintName("order_service_fk");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.IdOrderStatus).HasName("order_status_pk");

            entity.ToTable("order_status", "demo");

            entity.Property(e => e.IdOrderStatus)
                .ValueGeneratedNever()
                .HasColumnName("id_order_status");
            entity.Property(e => e.StatusName)
                .HasColumnType("character varying")
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.IdPosition).HasName("position_pk");

            entity.ToTable("position", "demo");

            entity.Property(e => e.IdPosition)
                .ValueGeneratedNever()
                .HasColumnName("id_position");
            entity.Property(e => e.NamePosition)
                .HasColumnType("character varying")
                .HasColumnName("name_position");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.IdService).HasName("service_pk");

            entity.ToTable("service", "demo");

            entity.Property(e => e.IdService)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_service");
            entity.Property(e => e.CodeService)
                .HasColumnType("character varying")
                .HasColumnName("code_service");
            entity.Property(e => e.NameService)
                .HasColumnType("character varying")
                .HasColumnName("name_service");
            entity.Property(e => e.PriceService).HasColumnName("price_service");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("user_pk");

            entity.ToTable("user", "demo");

            entity.Property(e => e.IdUser)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_user");
            entity.Property(e => e.IdClients).HasColumnName("id_clients");
            entity.Property(e => e.IdPosition).HasColumnName("id_position");
            entity.Property(e => e.UserImage)
                .HasColumnType("character varying")
                .HasColumnName("user_image");
            entity.Property(e => e.UserLogin)
                .HasColumnType("character varying")
                .HasColumnName("user_login");
            entity.Property(e => e.UserName)
                .HasColumnType("character varying")
                .HasColumnName("user_name");
            entity.Property(e => e.UserPassword)
                .HasColumnType("character varying")
                .HasColumnName("user_password");

            entity.HasOne(d => d.IdClientsNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdClients)
                .HasConstraintName("user_clients_fk");

            entity.HasOne(d => d.IdPositionNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdPosition)
                .HasConstraintName("user_position_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
