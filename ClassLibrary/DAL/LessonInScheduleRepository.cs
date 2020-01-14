using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Model;

namespace ClassLibrary.DAL
{
    public class LessonInScheduleRepository : EfRepository<LessonInSchedule, UniversityContext>, ILessonInScheduleRepository
    {
        public LessonInScheduleRepository(UniversityContext context) : base(context) { }

        //TODO Include
    }
}