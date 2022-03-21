namespace StudentsApi.Models.Response
{
    public class StudentResponse
    {
        public List<Student> Students { get; set; }
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
    }
}
