using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Model;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.BL.Services
{
    public class StudentService : EfService<Student, IStudentRepository>, IStudentService
    {
        public StudentService(IStudentRepository repository, ILogger<StudentService> logger) : base(repository, logger) { }
    }
}