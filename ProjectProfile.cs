using AutoMapper;
using ProjectsDbAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectsDbAPI
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDetialsDto>()
                .ForMember(x => x.DeptName, map => map.MapFrom(project => project.Department.DeptName))
                .ForMember(x => x.DeptShortName, map => map.MapFrom(project => project.Department.DeptShortName));

            CreateMap<ProjectDto, Project>();
                
        }
    }
}
