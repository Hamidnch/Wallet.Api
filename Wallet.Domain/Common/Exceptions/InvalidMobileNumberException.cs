namespace Wallet.Domain.Common.Exceptions
{
    internal sealed class InvalidMobileNumberException : DomainException
    {
        internal InvalidMobileNumberException(string message)
            : base(message)
        {
        }
    }
}