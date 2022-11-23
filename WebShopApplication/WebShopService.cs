using AutoMapper;
using FluentValidation;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopApplication;

public class WebShopService : IWebShopService {
    
    private IWebShopRepository Repository;
    
    private readonly IWebShopRepository _tShirtRepository;
    private readonly IValidator<WebShopDTOs> _postValidator;
    private readonly IValidator<Item> _tShirtValidator;
    private readonly IMapper _mapper;
    
    public WebShopService(IWebShopRepository repository)
    {
        if (repository == null)
        {
            throw new ArgumentException("Missing repository");
        }
        Repository = repository;
    }

    public List<Item> GetAllItems()
    {
        return _tShirtRepository.GetAllItems();
    }

    public Item CreateNewItem(WebShopDTOs dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return _tShirtRepository.CreateNewItem(_mapper.Map<Item>(dto));
    }

    public Item GetItemById(int id)
    {
        throw new NotImplementedException();
    }

    public void RebuildDB()
    {
        _tShirtRepository.RebuildDB();
    }

    public Item UpdateItem(int id, Item product)
    {
        throw new NotImplementedException();
    }

    public Item DeleteItem(int id)
    {
        throw new NotImplementedException();
    }
    
}