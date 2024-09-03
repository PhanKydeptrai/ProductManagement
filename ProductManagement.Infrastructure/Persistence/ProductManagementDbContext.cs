using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Infrastructure;

public class ProductManagementDbContext : DbContext
{
    public ProductManagementDbContext(DbContextOptions<ProductManagementDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }

    #region Cấu hình cho entity
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        #region Cấu hình cho entity Product
        modelBuilder.Entity<Product>()
                    .HasKey(p => p.ProductId);

        modelBuilder.Entity<Product>(enitty =>
        {
            enitty.Property(n => n.ProductName)
                .IsRequired()
                .HasColumnType("nvarchar(50)");
        });
        #endregion


        #region Cấu hình cho entity Category
        //Cấu hình cho entity Category
        modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(n => n.CategoryName)
                .IsRequired()
                .HasColumnType("nvarchar(50)");
        });

        //Cấu hình quan hệ 1-n với entity Product
        modelBuilder.Entity<Category>()
                    .HasMany(c => c.Products)
                    .WithOne(p => p.Category)
                    .HasForeignKey(p => p.CategoryId);
        #endregion
        
        #region Cấu hình cho entity User
        modelBuilder.Entity<User>().HasKey(u => u.UserId);
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(n => n.UserName)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            entity.Property(n => n.UserMail)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            entity.Property(n => n.Password)
                .IsRequired()
                .HasColumnType("varchar(10)");

        });
        #endregion

    }
    #endregion
}
