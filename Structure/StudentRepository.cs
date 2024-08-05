using EdTechAPI.Model;

namespace EdTechAPI.Structure
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }
    }
}