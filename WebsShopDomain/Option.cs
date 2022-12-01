namespace WebsShopDomain;


public class Option : BaseClass
{


    public string Name { get; set; }
    
    // public OptionGroup Group { get; set; }
    //
    // public List<Item> Items { get; set; }
    
    public Option(){}
    
    public Option(string optionDtoName)
    {
        Name = optionDtoName;
    }
}
