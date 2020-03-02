using ClassLibrary.BL.Interfaces.Notifications;
using ClassLibrary.BL.Interfaces.Reporting;
using ClassLibrary.BL.Interfaces.Repositories;
using ClassLibrary.BL.Interfaces.Services;
using ClassLibrary.BL.Notifications;
using ClassLibrary.BL.Reporting;
using ClassLibrary.BL.Services;
using ClassLibrary.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbContextExt<TContext>(this IServiceCollection services, string connectionString) where TContext : DbContext
        {
            services.AddDbContextPool<TContext>(options => options.UseSqlServer(connectionString));
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IHomeworkService, HomeworkService>();
            services.AddScoped<ILessonInScheduleService, LessonInScheduleService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IHomeworkRepository, HomeworkRepository>();
            services.AddScoped<ILessonInScheduleRepository, LessonInScheduleRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
        }

        public static void AddReporting(this IServiceCollection services)
        {
            services.AddScoped<IXmlReportGenerator, XmlReportGenerator>();
            services.AddScoped<ITxtReportGenerator, TxtReportGenerator>();
        }

        public static void AddNotifiers(this IServiceCollection services)
        {
            services.AddScoped<IEmailNotifier, EmailNotifier>();
            services.AddScoped<ISmsNotifier, SmsNotifier>();
        }
    }
}
