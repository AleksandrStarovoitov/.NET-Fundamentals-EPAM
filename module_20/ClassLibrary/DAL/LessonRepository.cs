using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Model;

namespace ClassLibrary.DAL
{
    public class LessonRepository : EfRepository<Lesson, UniversityContext>, ILessonRepository
    {
        public LessonRepository(UniversityContext context) : base(context) { }
    }
}