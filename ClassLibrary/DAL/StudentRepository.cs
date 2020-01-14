using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Model;

namespace ClassLibrary.DAL
{
    public class StudentRepository : EfRepository<Student, UniversityContext>, IStudentRepository
    {
        public StudentRepository(UniversityContext context) : base(context) { }

        //TODO Include
    }
}