using System.Text.RegularExpressions;
using Wallet.Common.CommonHelpers;
using Wallet.Domain.Common.Exceptions;

namespace Wallet.Domain.Common
{
    public readonly struct MobileNumber
    {
        private readonly string _mobileNumber = string.Empty;

        public MobileNumber(string mobileNumber)
        {
            if (string.IsNullOrWhiteSpace(mobileNumber) || string.IsNullOrEmpty(mobileNumber))
                throw new MobileNumberShouldNotBeEmptyException($"The {nameof(mobileNumber)} field is required.");

            mobileNumber = mobileNumber.Trim();

            if (!Regex.IsMatch(mobileNumber, Helper.RegExMobileValidation))
                throw new InvalidMobileNumberException($"Invalid {nameof(mobileNumber)} format.");

            _mobileNumber = mobileNumber;
        }

        public override string ToString() => _mobileNumber;
    }
}