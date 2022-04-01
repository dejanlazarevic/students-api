using AutoMapper;
using StudentsApi.Models;
using StudentsApi.Models.Command;

namespace StudentsApi.Mappers
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentCommand, Student>();
        }
    }
}
