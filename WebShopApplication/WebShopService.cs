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
    private readonly IValidator<TShirt> _tShirtValidator;
    private readonly IMapper _mapper;
    
    public WebShopService(IWebShopRepository repository)
    {
        if (repository == null)
        {
            throw new ArgumentException("Missing repository");
        }
        Repository = repository;
    }

    public List<TShirt> GetAllNTShirts()
    {
        return _tShirtRepository.GetAllTShirts();
    }

    public TShirt CreateNewTShirt(WebShopDTOs dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return _tShirtRepository.CreateNewTShirt(_mapper.Map<TShirt>(dto));
    }

    public TShirt GetTShirtById(int id)
    {
        throw new NotImplementedException();
    }

    public void RebuildDB()
    {
        throw new NotImplementedException();
    }

    public TShirt UpdateTShirt(int id, TShirt product)
    {
        throw new NotImplementedException();
    }

    public TShirt DeleteTShirt(int id)
    {
        throw new NotImplementedException();
    }

    public TShirt GetNumberOfSizesFromTShirts(string size)
    {
        throw new NotImplementedException();
    }
}