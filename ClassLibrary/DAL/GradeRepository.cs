using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Model;

namespace ClassLibrary.DAL
{
    public class GradeRepository : EfRepository<Grade, UniversityContext>, IGradeRepository
    {
        public GradeRepository(UniversityContext context) : base(context) { }

        //TODO Include
    }
}