﻿using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopInfrastructure;

public class WebShopRepository : IWebShopRepository
{
    private readonly WebShopDbContext _context; 
    
    public WebShopRepository(WebShopDbContext context)
    {
        _context = context;
    }
    
    public List<Item> GetAllItems()
    {
        return _context.ItemTable.ToList();
    }

    public Item CreateNewItem(Item item)
    {
        _context.ItemTable.Add(item);
        _context.SaveChanges();
        item.Price = 1111;
        return item;
    }

    public Item GetItemById(int id)
    {
        throw new NotImplementedException();
    }

    public void RebuildDB()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }

    public Item UpdateItem(Item item)
    {
        throw new NotImplementedException();
    }

    public Item DeleteItem(int id)
    {
        throw new NotImplementedException();
    }

    public Item[] GetAll()
    {
        throw new NotImplementedException();
    }

    Category[] IWebShopRepository.GetAllCat()
    {
        throw new NotImplementedException();
    }

    public Category CreateNewCategory(Category category)
    {
        _context.CategoryTable.Add(category);
        _context.SaveChanges();
        return category;
    }

    public List<Category> GetAllCategories()
    {
        return _context.CategoryTable.ToList();
    }

    public Option CreateNewOption(Option option)
    {
        _context.OptionTable.Add(option);
        _context.SaveChanges();
        return option;
    }

    public List<Option> GetAllOptions()
    {
        return _context.OptionTable.ToList();
    }
}