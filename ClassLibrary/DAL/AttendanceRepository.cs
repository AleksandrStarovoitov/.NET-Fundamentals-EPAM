using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Model;

namespace ClassLibrary.DAL
{
    public class AttendanceRepository : EfRepository<Attendance, UniversityContext>, IAttendanceRepository
    {
        public AttendanceRepository(UniversityContext context) : base(context) { }

        //TODO Include Student, LessonInSchedule
    }
}