using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Model;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.BL.Services
{
    public class LessonService : EfService<Lesson, ILessonRepository>, ILessonService
    {
        public LessonService(ILessonRepository repository, ILogger<LessonService> logger) : base(repository, logger) { }
    }
}