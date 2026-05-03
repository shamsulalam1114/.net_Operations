using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;

namespace BLL
{
    public class MapperConfig
    {
        static MapperConfiguration config = new MapperConfiguration(cfg =>
        {   
            cfg.CreateMap<Department,DepartmentDTO>().ReverseMap(); ;

            //cfg.CreateMap<Student,StudentDTO>().ReverseMap(); ;
            //cfg.CreateMap<Course,CourseDTO>().ReverseMap(); ;
            //
            //
            //
        });

        public static Mapper GetMapper() { 
            return new Mapper(config);
        }
    }
}
