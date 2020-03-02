using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Model;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.BL.Services
{
    public class HomeworkService : EfWithIncludeService<Homework, IHomeworkRepository>, IHomeworkService
    {
        public HomeworkService(IHomeworkRepository repository, ILogger<HomeworkService> logger) : base(repository, logger) { }
    }
}