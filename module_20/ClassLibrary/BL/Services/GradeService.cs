using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Model;

namespace ClassLibrary.BL.Services
{
    public class GradeService : EfWithIncludeService<Grade, IGradeRepository>, IGradeService
    {
        public GradeService(IGradeRepository repository) : base(repository) { }
    }
}