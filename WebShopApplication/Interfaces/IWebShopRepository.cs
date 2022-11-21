namespace WebShopApplication.Interfaces;

public class IWebShopRepository
{
    List<TShirt> GetAllBoxes();
    TShirt CreateNewBox(TShirt tShirt);
    TShirt GetBoxById(int id);
    void RebuildDB();
    TShirt UpdateBox(TShirt tShirt);
    TShirt DeleteBox(int id);
}