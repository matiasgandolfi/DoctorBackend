
using AutoMapper;
using DoctorApp.DTOs;
using DoctorApp.Models;
using Models.DTOs;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<EspecialidadModel, EspecialidadDto>()
                .ForMember(d => d.Estado, m => m.MapFrom(o => o.Estado == true ? 1 : 0));

            CreateMap<MedicoModel, MedicoDto>()
                .ForMember(d => d.Estado, m => m.MapFrom(o => o.Estado == true ? 1 : 0))
                .ForMember(d => d.NombreEspecialidad, m => m.MapFrom(o => o.Especialidad.NombreEspecialidad));


            CreateMap<PacienteModel, PacienteDto>()
                .ForMember(d => d.Estado, m => m.MapFrom(o => o.Estado == true ? 1 : 0));

            CreateMap<PacienteDto, PacienteModel>();


        }

    }
}
