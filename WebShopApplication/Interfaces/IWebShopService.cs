using WebShopApplication.DTOs;
using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopService
{
    List<TShirt> GetAllNTShirts();
    TShirt CreateNewTShirt(WebShopDTOs dto);
    TShirt GetTShirtById(int id);
    void RebuildDB();
    TShirt UpdateTShirt(int id, TShirt product);
    TShirt DeleteTShirt(int id);

}