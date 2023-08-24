using MediatR;
using Wallet.Application.Services;
using Wallet.Domain.Entities;
using Wallet.Domain.Events;

namespace Wallet.Application.Commands.Handlers
{
    public class UserCommandHandler :
        IRequestHandler<IncreaseCashCommand>,
        IRequestHandler<IncreaseNonCashCommand>,
        IRequestHandler<DecreaseCashCommand>,
        IRequestHandler<IncreaseCashFromReturnCommand>
    {
        private readonly IWalletService _walletService;
        private readonly IMediator _mediator;

        public UserCommandHandler(User user, IWalletService walletService, IMediator mediator)
        {
            _walletService = walletService;
            _mediator = mediator;
        }

        public async Task Handle(IncreaseCashCommand command, CancellationToken cancellationToken)
        {
            await _walletService.IncreaseCashBalanceAsync(command.WalletId, command.Amount);
            await _mediator.Publish(new CashBalanceIncreasedEvent(command.WalletId,
                command.Amount), cancellationToken);

            //_user.AddEvent(new WalletTransactionAddedEvent(_user.Wallet.Id, transaction));
        }

        public async Task Handle(IncreaseNonCashCommand command, CancellationToken cancellationToken)
        {
            await _walletService.IncreaseNonCashBalanceAsync(command.WalletId, command.Amount, command.NonCashSource);
            await _mediator.Publish(
                new NonCashBalanceIncreasedEvent(command.WalletId, command.Amount, command.NonCashSource), cancellationToken);

            //_user.AddEvent(new WalletTransactionAddedEvent(_user.Wallet.Id, transaction));
        }

        public async Task Handle(DecreaseCashCommand command, CancellationToken cancellationToken)
        {
            await _walletService.DecreaseCashBalanceAsync(command.WalletId, command.Amount);
            await _mediator.Publish(
                new CashBalanceDecreasedEvent(command.WalletId, command.Amount), cancellationToken);

            //_user.AddEvent(new WalletTransactionAddedEvent(_user.Wallet.Id, transaction));
        }

        public async Task Handle(IncreaseCashFromReturnCommand command, CancellationToken cancellationToken)
        {
            await _walletService.IncreaseCashFromReturnAsync(command.WalletId, command.Amount);
            await _mediator.Publish(
                new CashFromReturnIncreasedEvent(command.WalletId, command.Amount), cancellationToken);

            //_user.AddEvent(new WalletTransactionAddedEvent(_user.Wallet.Id, transaction));
        }
    }
}