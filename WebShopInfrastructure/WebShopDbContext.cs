﻿using Microsoft.EntityFrameworkCore;
using WebsShopDomain;

namespace WebShopInfrastructure;

public class WebShopDbContext  : DbContext
{
    public WebShopDbContext(DbContextOptions<WebShopDbContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Item>()
            .Property(i => i.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Item>()
            .HasOne<Category>()
            .WithMany(c => c.CategoryItems)
            .HasForeignKey(i => i.ItemCategoryId);

        modelBuilder.Entity<Category>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Option>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Option>()
            .HasMany(o => o.Items)
            .WithMany(i => i.Options)
            .UsingEntity(j => j.HasData(new { ItemId = 1, OptionId = 1 }));
        
        
    } 
    
    public DbSet<Item> ItemTable { get; set; }
    public DbSet<Category> CategoryTable { get; set; }
    public DbSet<Option> OptionTable { get; set; }
}