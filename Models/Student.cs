using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdTechAPI.Model
{
    [Table("student")]
    public class Student
    {
        [Key]
        public int ra { get; private set; }
        public string name { get; private set; }
        public string email { get; set; }
        public string cpf { get; set; }

        public Student(string name, string cpf, string email)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.cpf = cpf;
            this.email = email;
        }
    }
}
