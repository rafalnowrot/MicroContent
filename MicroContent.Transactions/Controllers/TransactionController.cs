using MediatR;
using MicroContent.Transactions.Application;
using MicroContent.Transactions.Application.Commands;
using MicroContent.Transactions.Application.Dto;
using MicroContent.Transactions.Application.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroContent.Transactions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<TransactionController>
        [HttpGet]
        public async Task<List<TransactionDto>> Get()
        {
            return  await _mediator.Send(new GetTransactionsList());
        }

        [HttpPost]
        public async Task<bool> Post(SetTransaction command)
        {
            return await _mediator.Send(command);
        }
    }
}
