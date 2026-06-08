using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ISApteka.Models;

namespace ISApteka.Data
{
    public class PharmacyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public PharmacyContext(DbContextOptions<PharmacyContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конвертер для DateTime (UTC)
            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(dateTimeConverter);
                    }
                }
            }

            // Настройка таблиц
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("orderitems");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductName).HasColumnName("product_name");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Login).HasColumnName("Login");
                entity.Property(e => e.Password).HasColumnName("Password");
                entity.Property(e => e.Role).HasColumnName("Role");
            });

            // Конвертация enum в int
            modelBuilder.Entity<Order>()
                .Property(o => o.Status)
                .HasConversion<int>();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Role)
                .HasConversion<int>();

            // Уникальный индекс для Login
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Login)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}