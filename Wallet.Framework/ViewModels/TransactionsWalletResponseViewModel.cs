using Wallet.Common.Enums;

namespace Wallet.Framework.ViewModels;

public record TransactionsWalletResponseViewModel(TransactionType Type, DateTime CreatedOn, decimal Amount, NonCashSource NonCashSource);

public class TransactionsWalletListResponseViewModel : List<TransactionsWalletResponseViewModel>
{
}