using System.Threading.Tasks;
using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Model;

namespace ClassLibrary.DAL
{
    public class LessonInScheduleRepository : EfWithIncludeRepository<LessonInSchedule, UniversityContext>, ILessonInScheduleRepository
    {
        public LessonInScheduleRepository(UniversityContext context) : base(context) { }

        public override async Task<LessonInSchedule> GetByIdWithIncludeAsync(int id)
        {
            return await GetByIdWithIncludeInternalAsync(id, lessonInSchedule => lessonInSchedule.Lesson, 
                lessonInSchedule => lessonInSchedule.Teacher);
        }
    }
}