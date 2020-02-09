using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Model;

namespace ClassLibrary.BL.Services
{
    public class StudentService : EfService<Student, IStudentRepository>, IStudentService
    {
        public StudentService(IStudentRepository repository) : base(repository) { }
    }
}