using MediatR;
using Wallet.Application.Features.Wallet.Commands;
using Wallet.Application.Features.Wallet.Services;
using Wallet.Domain.Events;

namespace Wallet.Application.Features.Wallet.Handlers.Command
{
    public class WalletCommandHandler :
        IRequestHandler<IncreaseCashCommand>,
        IRequestHandler<IncreaseNonCashCommand>,
        IRequestHandler<WithdrawCashCommand>,
        IRequestHandler<IncreaseCashFromReturnCommand>
    {
        private readonly IWalletService _walletService;
        private readonly IMediator _mediator;

        public WalletCommandHandler(IWalletService walletService, IMediator mediator)
        {
            _walletService = walletService;
            _mediator = mediator;
        }

        public async Task Handle(IncreaseCashCommand command, CancellationToken cancellationToken)
        {
            await _walletService.IncreaseCashBalanceAsync(command.UserId, command.Amount, cancellationToken);
            await _mediator.Publish(new CashBalanceIncreasedEvent(command.UserId,
                command.Amount), cancellationToken);

            //_user.AddEvent(new WalletTransactionAddedEvent(_user.Wallet.Id, transaction));
        }

        public async Task Handle(IncreaseNonCashCommand command, CancellationToken cancellationToken)
        {
            await _walletService.IncreaseNonCashBalanceAsync(command.UserId, command.Amount, command.NonCashSource, cancellationToken);
            await _mediator.Publish(
                new NonCashBalanceIncreasedEvent(command.UserId, command.Amount, command.NonCashSource), cancellationToken);

            //_user.AddEvent(new WalletTransactionAddedEvent(_user.Wallet.Id, transaction));
        }

        public async Task Handle(IncreaseCashFromReturnCommand command, CancellationToken cancellationToken)
        {
            await _walletService.IncreaseCashFromReturnAsync(command.UserId, command.Amount, cancellationToken);
            await _mediator.Publish(
                new CashFromReturnIncreasedEvent(command.UserId, command.Amount), cancellationToken);

            //_user.AddEvent(new WalletTransactionAddedEvent(_user.Wallet.Id, transaction));
        }

        public async Task Handle(WithdrawCashCommand command, CancellationToken cancellationToken)
        {
            await _walletService.WithdrawCashBalanceAsync(command.UserId, command.Amount, cancellationToken);
            await _mediator.Publish(
                new CashBalanceDecreasedEvent(command.UserId, command.Amount), cancellationToken);

            //_user.AddEvent(new WalletTransactionAddedEvent(_user.Wallet.Id, transaction));
        }
    }
}