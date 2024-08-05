namespace EdTechAPI.Model
{
    public interface IStudentRepository
    {
        void Add(Student student);

        List<Student> GetAll();
    }
}
