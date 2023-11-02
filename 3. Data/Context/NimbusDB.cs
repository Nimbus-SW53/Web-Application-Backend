using _3._Data.Model;
using Microsoft.EntityFrameworkCore;
namespace _3._Data.Context;

public class NimbusDB: DbContext
{
    public NimbusDB() {}
    public NimbusDB(DbContextOptions<NimbusDB> options) : base(options) {}
    
    //Tablas de la base de datos
    public DbSet<Product> Products { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Category> Categories { get; set;}
    public DbSet<Provider> Providers { get; set;}
    public DbSet<User> Users { get; set;}
    
    //Establecer la conexión a la base de datos
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=sql10.freemysqlhosting.net,3306;Uid=sql10658839;Pwd=GkG3nAYau1;Database=sql10658839;", serverVersion);
        }
    }
    
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 3);
        
        //Configurar la tabla Product Software
        builder.Entity<Product>().ToTable("Product");
        builder.Entity<Product>().HasKey(p => p.Id); 
        builder.Entity<Product>().Property(p => p.SoftwareName).IsRequired().HasMaxLength(100);
        builder.Entity<Product>().Property(p => p.Price).IsRequired();
        builder.Entity<Product>().Property(p => p.Description).IsRequired().HasMaxLength(500);
        builder.Entity<Product>().Property(p => p.UrlImagePreview).IsRequired();
        builder.Entity<Product>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Product>().Property(p => p.IsActive).HasDefaultValue(true);
        
        //Configurar la tabla Review
        builder.Entity<Review>().ToTable("Review");
        builder.Entity<Review>().HasKey(r => r.Id); 
        builder.Entity<Review>().Property(r => r.Score).IsRequired();
        builder.Entity<Review>().Property(r => r.Description).IsRequired().HasMaxLength(200);
        builder.Entity<Review>().Property(r => r.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Review>().Property(r => r.IsActive).HasDefaultValue(true);
        
        //Configurar la tabla Category
        builder.Entity<Category>().ToTable("Category");
        builder.Entity<Category>().HasKey(c => c.Id); 
        builder.Entity<Category>().Property(c => c.CategoryName).IsRequired().HasMaxLength(120);
        builder.Entity<Category>().Property(c => c.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Category>().Property(c => c.IsActive).HasDefaultValue(true);
        
        //Configurar la tabla Provider
        builder.Entity<Provider>().ToTable("Provider");
        builder.Entity<Provider>().HasKey(p => p.Id); 
        builder.Entity<Provider>().Property(p => p.Name).IsRequired().HasMaxLength(90);
        builder.Entity<Provider>().Property(p => p.UrlLogo).IsRequired();
        builder.Entity<Provider>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Provider>().Property(p => p.IsActive).HasDefaultValue(true);
        
        //Configurar la tabla User
        builder.Entity<User>().ToTable("User");
        builder.Entity<User>().HasKey(u => u.Id); 
        builder.Entity<User>().Property(u => u.FullName).IsRequired().HasMaxLength(100);
        builder.Entity<User>().Property(u => u.UserName).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(u => u.Email).IsRequired();
        builder.Entity<User>().Property(u => u.Password).IsRequired();
        builder.Entity<User>().Property(u => u.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<User>().Property(u => u.IsActive).HasDefaultValue(true);
    }
}