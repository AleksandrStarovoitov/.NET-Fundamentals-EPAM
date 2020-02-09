using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Model;

namespace ClassLibrary.BL.Services
{
    public class HomeworkService : EfWithIncludeService<Homework, IHomeworkRepository>, IHomeworkService
    {
        public HomeworkService(IHomeworkRepository repository) : base(repository) { }
    }
}