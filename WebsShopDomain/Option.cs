using System.ComponentModel.DataAnnotations.Schema;

namespace WebsShopDomain;


public class Option : BaseClass
{


    public string Name { get; set; }
    [ForeignKey("OptionGroup")]
    public int OptionGroupId { get; set; }
    public OptionGroup Group { get; set; }
    
    // public List<ItemOption> ItemOptions { get; set; }
    
    public Option(){}
    
    public Option(string optionDtoName, int optionGroupId)
    {
        Name = optionDtoName;
        OptionGroupId = optionGroupId;
    }
}
