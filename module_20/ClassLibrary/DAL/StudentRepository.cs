using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Model;

namespace ClassLibrary.DAL
{
    public class StudentRepository : EfRepository<Student, UniversityContext>, IStudentRepository
    {
        public StudentRepository(UniversityContext context) : base(context) { }
    }
}