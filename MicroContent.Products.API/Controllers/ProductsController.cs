using MediatR;
using MicroContent.Products.Application.Commands;
using MicroContent.Products.Application.Dto;
using MicroContent.Products.Application.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroContent.Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get()
        {
            return await _mediator.Send(new GetProductsList());
        }
        
        [HttpPost]
        public async Task<bool> Post( PostProduct command)
        {
            return  await _mediator.Send(command);
        }
        
        [HttpPut]
        public async Task<bool> PutAsync(UpdateProduct command)
        {
            return await _mediator.Send(command);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
