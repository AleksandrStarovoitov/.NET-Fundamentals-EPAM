using System.Threading.Tasks;
using ClassLibrary.BL.Interfaces.Notifications;
using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Model;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.BL.Services
{
    public class AttendanceService : EfWithIncludeService<Attendance, IAttendanceRepository>, IAttendanceService
    {
        private readonly IEmailNotifier notifier;

        public AttendanceService(IAttendanceRepository repository, ILogger<AttendanceService> logger,
            IEmailNotifier notifier) : base(repository, logger)
        {
            this.notifier = notifier;
        }

        public override async Task<Attendance> AddAsync(Attendance entity)
        {
            var attendanceFromDb = await base.AddAsync(entity);
            
            var count = await repository.CountAsync(attendance => 
                attendance.StudentId == entity.StudentId && !attendance.IsPresent);
            if (count > 3)
            {
                notifier?.SendNotification($"Student with id = {entity.StudentId} was absent > 3 times. Email sent.");
            }

            return attendanceFromDb;
        }
    }
}