using StudentsApi.Models;
using StudentsApi.Models.Command;
using StudentsApi.Models.Response;

namespace StudentsApi.Repository
{
    public interface IStudentRepository
    {
        public StudentResponse GetStudents(int page, string? firstName);
        public Student GetStudent(int id);
        public void CreateStudent(StudentCommand student);
        public bool UpdateStudent(int id, Student student);
        bool DeleteStudent(int id);
    }
}
