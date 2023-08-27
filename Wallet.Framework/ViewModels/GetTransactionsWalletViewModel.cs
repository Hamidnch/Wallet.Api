using Wallet.Common.Enums;

namespace Wallet.Framework.ViewModels;

public record GetTransactionsWalletViewModel(Guid UserId, TransactionType Type, DateTime? From, DateTime? To);

