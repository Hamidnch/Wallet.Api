using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wallet.Application.Features.Wallet.Commands;
using Wallet.Application.Features.Wallet.Dtos;
using Wallet.Application.Features.Wallet.Queries;
using Wallet.Domain.Common;
using Wallet.Framework.ViewModels;

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
        public async Task<IActionResult> IncreaseCash([FromBody] IncreaseCashViewModel model)
        {
            var command =
                new IncreaseCashCommand(model.UserId, new PositiveMoney(model.Money));
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost("increase/noncash")]
        public async Task<IActionResult> IncreaseNonCash([FromBody] IncreaseNonCashViewModel model)
        {
            var command =
                new IncreaseNonCashCommand(model.UserId, new PositiveMoney(model.Amount), model.NonCashSource);
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost("decrease/cash")]
        public async Task<IActionResult> DecreaseCash([FromBody] DecreaseCashViewModel model)
        {
            var command =
                new DecreaseCashCommand(model.UserId, new PositiveMoney(model.Amount));
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost("increase/cashfromreturn")]
        public async Task<IActionResult> IncreaseCashFromReturn([FromBody] IncreaseCashFromReturnViewModel model)
        {
            var command =
                new IncreaseCashFromReturnCommand(model.UserId, new PositiveMoney(model.Amount));
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet("transactions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWalletTransactions([FromQuery] GetTransactionsWalletViewModel model)
        {
            var dto = new TransactionsWalletRequestDto(model.UserId, model.Type, model.TransactionDate);
            var query = new GetWalletTransactionsQuery(dto);
            var transactions = await _mediator.Send(query);

            return Ok(transactions);
        }
    }
}