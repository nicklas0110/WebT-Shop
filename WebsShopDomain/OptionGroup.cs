namespace WebsShopDomain;

public class OptionGroup : BaseClass
{
    
    public OptionGroup()
    {
    }
    public OptionGroup(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}