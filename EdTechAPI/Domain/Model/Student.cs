using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Model
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int ra { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? cpf { get; set; }

        public Student() { }

        public Student(string name, string email, string cpf)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.email = email;
            this.cpf = cpf;
        }
    }
}
