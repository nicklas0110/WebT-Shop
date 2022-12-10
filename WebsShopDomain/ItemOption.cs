namespace WebsShopDomain;

public class ItemOption : BaseClass
{
    public int ItemId { get; set; }
    public int OptionId { get; set; }
    
    public Option Option { get; set; }
    
    public Item Item { get; set; }
}