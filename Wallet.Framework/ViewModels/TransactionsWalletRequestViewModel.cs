using Wallet.Common.Enums;

namespace Wallet.Framework.ViewModels;

public record TransactionsWalletRequestViewModel(Guid UserId, TransactionType Type, DateTime? From, DateTime? To);

