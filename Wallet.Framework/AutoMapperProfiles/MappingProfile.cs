using AutoMapper;
using Wallet.Application.Features.Wallet.Dtos.Response;
using Wallet.Framework.ViewModels;

namespace Wallet.Framework.AutoMapperProfiles;

public partial class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TransactionsWalletResponseDto, TransactionsWalletResponseViewModel>().ReverseMap();
    }
}