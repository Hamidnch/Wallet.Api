namespace Wallet.Domain.Common.Exceptions
{
    public sealed class MobileNumberShouldNotBeEmptyException : DomainException
    {
        internal MobileNumberShouldNotBeEmptyException(string message)
            : base(message)
        {
        }
    }
}