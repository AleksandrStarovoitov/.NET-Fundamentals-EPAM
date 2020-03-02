using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Model;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.BL.Services
{
    public class TeacherService : EfService<Teacher, ITeacherRepository>, ITeacherService
    {
        public TeacherService(ITeacherRepository repository, ILogger<TeacherService> logger) : base(repository, logger) { }
    }
}