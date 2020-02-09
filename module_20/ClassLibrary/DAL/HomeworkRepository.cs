using System.Threading.Tasks;
using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Model;

namespace ClassLibrary.DAL
{
    public class HomeworkRepository : EfWithIncludeRepository<Homework, UniversityContext>, IHomeworkRepository
    {
        public HomeworkRepository(UniversityContext context) : base(context) { }

        public override async Task<Homework> GetByIdWithIncludeAsync(int id)
        {
            return await GetByIdWithIncludeInternalAsync(id, homework => homework.Student,
                homework => homework.LessonInSchedule);
        }
    }
}