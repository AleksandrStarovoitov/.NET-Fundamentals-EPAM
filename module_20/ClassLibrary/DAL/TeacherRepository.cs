using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Model;

namespace ClassLibrary.DAL
{
    public class TeacherRepository : EfRepository<Teacher, UniversityContext>, ITeacherRepository
    {
        public TeacherRepository(UniversityContext context) : base(context) { }
    }
}