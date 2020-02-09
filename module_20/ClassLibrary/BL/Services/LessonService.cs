using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Model;

namespace ClassLibrary.BL.Services
{
    public class LessonService : EfService<Lesson, ILessonRepository>, ILessonService
    {
        public LessonService(ILessonRepository repository) : base(repository) { }
    }
}