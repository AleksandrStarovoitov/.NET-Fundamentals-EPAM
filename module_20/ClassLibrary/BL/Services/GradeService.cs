using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Model;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.BL.Services
{
    public class GradeService : EfWithIncludeService<Grade, IGradeRepository>, IGradeService
    {
        public GradeService(IGradeRepository repository, ILogger<GradeService> logger) : base(repository, logger) { }
    }
}