using Microsoft.EntityFrameworkCore;
using WebsShopDomain;

namespace WebShopInfrastructure;

public class DatabaseContext  : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Webshop 
        modelBuilder.Entity<Item>()
            .Property(i => i.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Item>();

        modelBuilder.Entity<Category>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Option>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<ItemOption>()
            .Property(io => io.Id)
            .ValueGeneratedOnAdd();
        // modelBuilder.Entity<ItemOption>()
        //     .HasOne<Item>(io => io.Item)
        //     .WithMany().HasForeignKey(io => io.ItemId);
        // modelBuilder.Entity<ItemOption>()
        //     .HasOne<Option>(io => io.Option)
        //     .WithMany().HasForeignKey(io => io.OptionId);

        
        //User Login
        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<User>()
            .HasIndex((u => u.Email))
            .IsUnique();
        
        //option group
        modelBuilder.Entity<OptionGroup>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();


    } 
    
    public DbSet<Item> ItemTable { get; set; }
    public DbSet<Category> CategoryTable { get; set; }
    public DbSet<Option> OptionTable { get; set; }
    public DbSet<User> UserTable { get; set; }
    public DbSet<ItemOption> ItemOptionTable { get; set; }
    public DbSet<OptionGroup> OptionGroupTable { get; set; }
}