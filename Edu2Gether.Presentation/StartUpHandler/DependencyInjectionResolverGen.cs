using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Edu2Gether.DataAccess.Models;
using Edu2Gether.BusinessLogic.Services;
using Edu2Gether.DataAccess.Repositories;

namespace Edu2Gether.BusinessLogic.Generations.DependencyInjection
{
    public static class DependencyInjectionResolverGen
    {
        public static IServiceCollection InitializerDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<DbContext, Edu2GetherContext>();
        
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingRepository, BookingRepository>();
        
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseRepository, CourseRepository>();
        
            services.AddScoped<IMajorService, MajorService>();
            services.AddScoped<IMajorRepository, MajorRepository>();
        
            services.AddScoped<IMarkService, MarkService>();
            services.AddScoped<IMarkRepository, MarkRepository>();
        
            services.AddScoped<IMenteeService, MenteeService>();
            services.AddScoped<IMenteeRepository, MenteeRepository>();
        
            services.AddScoped<IMentorService, MentorService>();
            services.AddScoped<IMentorRepository, MentorRepository>();
        
            services.AddScoped<IMentorMajorService, MentorMajorService>();
            services.AddScoped<IMentorMajorRepository, MentorMajorRepository>();
        
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
        
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
        
            services.AddScoped<ISlotService, SlotService>();
            services.AddScoped<ISlotRepository, SlotRepository>();
        
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
        
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IWalletRepository, WalletRepository>();

            return services;
        }
    }
}
