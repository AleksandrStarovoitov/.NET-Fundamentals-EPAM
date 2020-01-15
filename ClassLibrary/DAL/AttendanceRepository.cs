using System.Threading.Tasks;
using ClassLibrary.BL.Interfaces;
using ClassLibrary.BL.Model;

namespace ClassLibrary.DAL
{
    public class AttendanceRepository : EfWithIncludeRepository<Attendance, UniversityContext>, IAttendanceRepository
    {
        public AttendanceRepository(UniversityContext context) : base(context) { }

        public override async Task<Attendance> GetByIdWithIncludeAsync(int id)
        {
            return await GetByIdWithIncludeInternalAsync(id, attendance => attendance.Student, 
                attendance => attendance.LessonInSchedule);
        }
    }
}