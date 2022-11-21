using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopRepository
{
    List<TShirt> GetAllTShirts();
    TShirt CreateNewTShirt(TShirt tShirt);
    TShirt GetTShirtById(int id);
    void RebuildDB();
    TShirt UpdateTShirt(TShirt tShirt);
    TShirt DeleteTShirt(int id);
}