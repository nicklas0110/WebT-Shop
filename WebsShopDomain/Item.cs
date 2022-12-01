namespace WebsShopDomain;

public class Item : BaseClass
{
    

    public string Name { get; set; }
    public decimal Price { get; set; }
    //public int ItemCategoryId { get; set; }
   // public Category ItemCategory { get; set; }
   // public List<Option> Options { get; set; }
    
    public Item(){}
    public Item(string dtoName, decimal dtoPrice)
    {
        Name = dtoName;
        Price = dtoPrice;
    }
}