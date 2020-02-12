using System.Threading.Tasks;
using ClassLibrary.BL.Interfaces.Notifications;
using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Model;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.BL.Services
{
    public class GradeService : EfWithIncludeService<Grade, IGradeRepository>, IGradeService
    {
        private readonly ISmsNotifier notifier;

        public GradeService(IGradeRepository repository, ILogger<GradeService> logger, ISmsNotifier notifier) : base(
            repository, logger)
        {
            this.notifier = notifier;
        }

        public override async Task<Grade> AddAsync(Grade entity)
        {
            var gradeFromDb = await base.AddAsync(entity);

            var average = await repository.AverageAsync(g =>
                g.StudentId == entity.StudentId, g => g.Mark);

            if (average < 4)
            {
                notifier?.SendNotification($"Student with id = {entity.StudentId} has average mark < 4. Sms sent.");
            }

            return gradeFromDb;
        }
    }
}