using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Employee.Domain.Commands;
using Employee.Domain.Entities.ValueObjects;

namespace Employee.Domain.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeCommand, Entities.Employee>()
                .ConstructUsing(src => new Entities.Employee(src.FirstName,src.LastName,src.DocumentNumber ))
                .ForPath(dest => dest.DocumentNumber, opt => opt.MapFrom(src => src.DocumentNumber))
                .ForPath(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .AfterMap((s, d) =>
                {
                    foreach (var a in s.Address)
                    {
                        d.AddAddress(a);
                    }

                    foreach (var p in s.Phone)
                    {
                        d.AddPhone(p);
                    }
                });


            CreateMap<UpdateEmployeeCommand, Entities.Employee>()
               .ConstructUsing(src => new Entities.Employee(src.FirstName, src.LastName))
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        }
    }
}
