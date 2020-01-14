using System.Threading.Tasks;
using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Model;

namespace ClassLibrary.DAL
{
    public class AttendanceRepository : EfRepository<Attendance, UniversityContext>, IAttendanceRepository
    {
        public AttendanceRepository(UniversityContext context) : base(context) { }

        public Task<Attendance> GetByIdWithStudentAndLessonAsync(int id)
        {
            return GetByIdWithIncludeAsync(id, attendance => attendance.Student, attendance => attendance.LessonInSchedule);
        }
    }
}