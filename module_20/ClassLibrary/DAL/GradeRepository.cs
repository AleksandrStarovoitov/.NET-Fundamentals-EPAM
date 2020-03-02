using System.Threading.Tasks;
using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Model;

namespace ClassLibrary.DAL
{
    public class GradeRepository : EfWithIncludeRepository<Grade, UniversityContext>, IGradeRepository
    {
        public GradeRepository(UniversityContext context) : base(context) { }

        public override async Task<Grade> GetByIdWithIncludeAsync(int id)
        {
            return await GetByIdWithIncludeInternalAsync(id, grade => grade.Student, 
                grade => grade.LessonInSchedule);
        }
    }
}