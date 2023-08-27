using AutoMapper;
using Wallet.Application.Features.Wallet.Dtos.Response;
using Wallet.Domain.Common;
using Wallet.Domain.Entities;

namespace Wallet.Application.AutoMapperProfiles;

public partial class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PositiveMoney, decimal>().ConvertUsing(source => source.ToDecimal);
        CreateMap<TransactionWallet, TransactionsWalletResponseDto>().ReverseMap();
    }
}