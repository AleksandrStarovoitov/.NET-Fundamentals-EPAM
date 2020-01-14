using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Model;

namespace ClassLibrary.DAL
{
    public class HomeworkRepository : EfRepository<Homework, UniversityContext>, IHomeworkRepository
    {
        public HomeworkRepository(UniversityContext context) : base(context) { }

        //TODO Include
    }
}