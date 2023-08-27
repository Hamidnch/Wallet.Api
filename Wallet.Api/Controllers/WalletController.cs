using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wallet.Application.Features.Wallet.Commands;
using Wallet.Application.Features.Wallet.Dtos;
using Wallet.Application.Features.Wallet.Queries;
using Wallet.Domain.Common;
using Wallet.Framework;
using Wallet.Framework.ViewModels;

namespace Wallet.Api.Controllers;

public class WalletController : BaseApiController
{
    private readonly IMediator _mediator;

    public WalletController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("increase/cash")]
    public async Task<IActionResult> IncreaseCash([FromQuery] IncreaseCashViewModel model)
    {
        var command =
            new IncreaseCashCommand(model.UserId, new PositiveMoney(model.Money));
        await _mediator.Send(command);

        return Ok();
    }

    [HttpPost("increase/noncash")]
    public async Task<IActionResult> IncreaseNonCash([FromQuery] IncreaseNonCashViewModel model)
    {
        var command =
            new IncreaseNonCashCommand(model.UserId, new PositiveMoney(model.Amount), model.NonCashSource);
        await _mediator.Send(command);

        return Ok();
    }

    [HttpPost("withdraw/cash")]
    public async Task<IActionResult> WithdrawCash([FromQuery] DecreaseCashViewModel model)
    {
        var command =
            new DecreaseCashCommand(model.UserId, new PositiveMoney(model.Amount));
        await _mediator.Send(command);

        return Ok();
    }

    [HttpPost("increase/cashfromreturn")]
    public async Task<IActionResult> IncreaseCashFromReturn([FromQuery] IncreaseCashFromReturnViewModel model)
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
        var dto = new TransactionsWalletRequestDto(model.UserId, model.Type, model.From, model.To);
        var query = new GetWalletTransactionsQuery(dto);
        var transactions = await _mediator.Send(query);

        return Ok(transactions);
    }
}