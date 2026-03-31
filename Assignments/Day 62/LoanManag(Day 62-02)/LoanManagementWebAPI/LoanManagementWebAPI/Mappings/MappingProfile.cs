using AutoMapper;
using LoanManagementWebAPI.DTOs;

namespace LoanManagementWebAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoanCreateDTO, Models.Loan>();
            CreateMap<LoanPutDTO, Models.Loan>();

            CreateMap<DTOs.LoanGetDTO, Models.Loan>();
        }
    }
}
 