namespace WebsShopDomain;

public class OptionGroup : BaseClass
{
    public OptionGroup(string optionGroupsName)
    {
        Name = optionGroupsName;    }

    public string Name { get; set; }
}