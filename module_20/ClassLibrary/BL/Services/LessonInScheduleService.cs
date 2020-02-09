using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Model;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.BL.Services
{
    public class LessonInScheduleService : EfWithIncludeService<LessonInSchedule, ILessonInScheduleRepository>, ILessonInScheduleService
    {
        public LessonInScheduleService(ILessonInScheduleRepository repository, ILogger<LessonInScheduleService> logger) : base(repository, logger) { }
    }
}