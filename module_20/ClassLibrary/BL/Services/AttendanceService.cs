using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Model;

namespace ClassLibrary.BL.Services
{
    public class AttendanceService : EfWithIncludeService<Attendance, IAttendanceRepository>, IAttendanceService
    {
        public AttendanceService(IAttendanceRepository repository) : base(repository) { }
    }
}