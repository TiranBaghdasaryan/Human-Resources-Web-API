using AutoMapper;
using Human_Resources_Web_API.Entities;
using Human_Resources_Web_API.Models.ViewModels;

namespace Human_Resources_Web_API.Models.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Employee to EmployeeViewModel
        
            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(destination => destination.PayrollInformation,
                    option => option.MapFrom(src => src.HumanResourceData.PayrollInformation))
                .ForMember(destination => destination.SocialSecurityNumber,
                    option => option.MapFrom(src => src.HumanResourceData.SocialSecurityNumber))
                .ForMember(destination => destination.Salary,
                    option => option.MapFrom(src => src.HumanResourceData.Salary));
           
            #endregion
            
            #region EmployeeRequest to Employee

            CreateMap<Employee, EmployeeRequest>()
                .ForMember(destination => destination.PayrollInformation,
                    option => option.MapFrom(src => src.HumanResourceData.PayrollInformation))
                .ForMember(destination => destination.SocialSecurityNumber,
                    option => option.MapFrom(src => src.HumanResourceData.SocialSecurityNumber))
                .ForMember(destination => destination.Salary,
                    option => option.MapFrom(src => src.HumanResourceData.Salary))
                .ReverseMap();

            #endregion


        }
    }
}