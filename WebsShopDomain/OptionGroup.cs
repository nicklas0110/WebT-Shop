namespace WebsShopDomain;

public class OptionGroup : BaseClass
{
    public OptionGroup(string optionDtoName)
    {
        Name = optionDtoName;
    }

    public string Name { get; set; }
}