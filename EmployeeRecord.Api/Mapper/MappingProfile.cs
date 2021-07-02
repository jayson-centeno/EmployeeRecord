using AutoMapper;
using EmployeeRecord.Api.ViewModel;
using EmployeeRecord.Domain.CQS.Command;
using EmployeeRecord.Domain.CQS.Query;
using EmployeeRecord.Domain.Model;
using EmployeeRecord.Entities;

namespace EmployeeRecord.Api.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<EmployeeResult, EmployeeVM>().ReverseMap();

			CreateMap<GetEmployeesQuery, GetEmployeesQueryVM>().ReverseMap();
			CreateMap<EmployeeVM, EmployeeResult>().ReverseMap();
			CreateMap<EmployeesVM, EmployeeResults>().ReverseMap();

			CreateMap<CreateEmployeeCommand, NewEmployeeVM>().ReverseMap();
			CreateMap<UpdateEmployeeCommand, EmployeeVM>().ReverseMap();

			CreateMap<CreateEmployeeCommand, Employee>().ReverseMap();
			CreateMap<UpdateEmployeeCommand, Employee>().ReverseMap();
			CreateMap<Employee, EmployeeResult>().ReverseMap();

		}
	}
}
