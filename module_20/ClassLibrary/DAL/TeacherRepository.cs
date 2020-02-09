using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Model;

namespace ClassLibrary.DAL
{
    public class TeacherRepository : EfRepository<Teacher, UniversityContext>, ITeacherRepository
    {
        public TeacherRepository(UniversityContext context) : base(context) { }

        //TODO Include
    }
}