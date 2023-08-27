using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wallet.Application.Features.Wallet.Commands;
using Wallet.Application.Features.Wallet.Dtos.Request;
using Wallet.Application.Features.Wallet.Queries;
using Wallet.Domain.Common;
using Wallet.Framework;

namespace Wallet.Api.Controllers;

public class WalletController : BaseApiController
{
    private readonly IMediator _mediator;

    public WalletController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("increase/cash")]
    public async Task<IActionResult> IncreaseCash([FromQuery] IncreaseCashDto dto)
    {
        var command =
            new IncreaseCashCommand(dto.UserId, new PositiveMoney(dto.Amount));
        await _mediator.Send(command);

        return Ok();
    }

    [HttpPost("increase/noncash")]
    public async Task<IActionResult> IncreaseNonCash([FromQuery] IncreaseNonCashDto dto)
    {
        var command =
            new IncreaseNonCashCommand(dto.UserId, new PositiveMoney(dto.Amount), dto.NonCashSource);
        await _mediator.Send(command);

        return Ok();
    }

    [HttpPost("withdraw/cash")]
    public async Task<IActionResult> WithdrawCash([FromQuery] WithdrawCashDto dto)
    {
        var command =
            new WithdrawCashCommand(dto.UserId, new PositiveMoney(dto.Amount));
        await _mediator.Send(command);

        return Ok();
    }

    [HttpPost("increase/cashfromreturn")]
    public async Task<IActionResult> IncreaseCashFromReturn([FromQuery] IncreaseCashFromReturnDto dto)
    {
        var command =
            new IncreaseCashFromReturnCommand(dto.UserId, new PositiveMoney(dto.Amount));
        await _mediator.Send(command);

        return Ok();
    }

    [HttpGet("transactions")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetWalletTransactions([FromQuery] TransactionsWalletRequestDto dto)
    {
        //var dto = new TransactionsWalletRequestDto(dto.UserId, dto.Type, dto.From, dto.To);
        var query = new GetWalletTransactionsQuery(dto);
        var transactions = await _mediator.Send(query);

        return Ok(transactions);
    }
}