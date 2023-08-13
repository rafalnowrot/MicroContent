using MicroContent.CompanyProduct.API.Models;
using MicroContent.CompanyProduct.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroContent.CompanyProduct.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<IEnumerable<Product>> Get()
    {
        return await _productService.GetAllProducts();
    }
    
    [HttpPost]
    public async Task Post(Product request)
    {
        await _productService.Save(request);
    }

}
