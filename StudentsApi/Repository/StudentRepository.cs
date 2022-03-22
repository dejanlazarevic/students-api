using StudentsApi.Database;
using StudentsApi.Models;
using StudentsApi.Models.Response;

namespace StudentsApi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentRepository(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }


        public void CreateStudent(Student student)
        {
            _studentDbContext.Students.Add(student);
            _studentDbContext.SaveChanges();
        }

        public Student GetStudent(int id)
        {
            var student = _studentDbContext.Students.Where(x => x.Id == id).FirstOrDefault();
            return student;
        }

        public StudentResponse GetStudents(int page, string? firstName)
        {
            var defaultPageSize = 10f;
            var students = _studentDbContext.Students.ToList();

            var pageCount = Math.Ceiling(students.Count / defaultPageSize);

            if (!string.IsNullOrEmpty(firstName) && students.Count > 0)
            {
                students = students.Where(x => x.FirstName == firstName).ToList();
                pageCount = Math.Ceiling(students.Count / defaultPageSize);
            }

            var studentsPaged = students.Skip((page - 1) * (int)defaultPageSize).Take((int)defaultPageSize).ToList();

            StudentResponse studentResponse = new StudentResponse
            {
                Students = studentsPaged,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return studentResponse;
        }

        public bool UpdateStudent(int id, Student student)
        {
            var studentFromDb = _studentDbContext.Students.Where(x => x.Id == id).FirstOrDefault();

            if (studentFromDb == null)
            {
                return false;
            }

            studentFromDb.FirstName = student.FirstName;
            studentFromDb.LastName = student.LastName;
            studentFromDb.Email = student.Email;
            studentFromDb.PhoneNumber = student.PhoneNumber;
            studentFromDb.Class = student.Class;
            studentFromDb.DateOfBirth = student.DateOfBirth;
            studentFromDb.IsActive = student.IsActive;

            _studentDbContext.SaveChanges();

            return true;
        }

        //TODO: Delete Student

        public bool DeleteStudent(int id)
        {
            var studentFromDb = _studentDbContext.Students.Where(x => x.Id == id).FirstOrDefault();

            if (studentFromDb == null)
            {
                return false;
            }

            _studentDbContext.Students.Remove(studentFromDb);
            _studentDbContext.SaveChanges();
            return true;
        }
    }
}
