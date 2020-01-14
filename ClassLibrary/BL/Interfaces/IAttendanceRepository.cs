using System.Threading.Tasks;
using ClassLibrary.BL.Model;

namespace ClassLibrary.BL.Interfaces
{
    public interface IAttendanceRepository : IAsyncRepository<Attendance>
    {
        Task<Attendance> GetByIdWithStudentAndLessonAsync(int id);
    }
}
