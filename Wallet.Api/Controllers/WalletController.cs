using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wallet.Application.Features.Wallet.Commands;
using Wallet.Application.Features.Wallet.Queries;

namespace Wallet.Api.Controllers
{
    [ApiController]
    [Route("api/wallet")]
    public class WalletController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WalletController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("increase/cash")]
        public async Task<IActionResult> IncreaseCash([FromBody] IncreaseCashCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("increase/noncash")]
        public async Task<IActionResult> IncreaseNonCash([FromBody] IncreaseNonCashCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("decrease/cash")]
        public async Task<IActionResult> DecreaseCash([FromBody] DecreaseCashCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("increase/cashfromreturn")]
        public async Task<IActionResult> IncreaseCashFromReturn([FromBody] IncreaseCashFromReturnCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("transactions/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWalletTransactions(Guid userId)
        {
            var query = new GetWalletTransactionsQuery(userId);
            var transactions = await _mediator.Send(query);
            return Ok(transactions);
        }
    }
}