using AutoMapper;
using System.Linq;
using WebApi.Domain.DTOs;
using WebApi.Domain.Model;

namespace WebApi.Infraestrutura.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ConnectionContext _context;
        private readonly IMapper _mapper;

        public StudentRepository(ConnectionContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public List<StudentDTO> GetAll()
        {
            var students = _context.Students.ToList();
            return _mapper.Map<List<StudentDTO>>(students);
        }


        public Student? Get(int ra)
        {
            return _context.Students.Find(ra);
        }

        public void Delete(int ra)
        {
            var student = _context.Students.FirstOrDefault(s => s.ra == ra);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }

}
