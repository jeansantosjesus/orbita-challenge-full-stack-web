using Microsoft.EntityFrameworkCore.Update.Internal;
using WebApi.Domain.DTOs;
using WebApi.Domain.Model;

namespace WebApi.Domain.Model
{
    public interface IStudentRepository
    {
        void Add(Student student);
        List<StudentDTO> GetAll();
        Student Get(int ra);
        void Delete(int ra);
        void Update(Student student);
    }
}
