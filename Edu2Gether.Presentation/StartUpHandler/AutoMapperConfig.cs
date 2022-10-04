using AutoMapper;
using Edu2Gether.BusinessLogic.AutoMapperModule;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu2Gether.Presentation.StartUpHandler
{
    public static class AutoMapperConfig
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.ConfigBookingModule();
                mc.ConfigCourseModule();
                mc.ConfigMajorModule();
                mc.ConfigMarkModule();
                mc.ConfigMenteeModule();
                mc.ConfigMentorMajorModule();
                mc.ConfigMentorModule();
                mc.ConfigPaymentModule();
                mc.ConfigRoleModule();
                mc.ConfigSlotModule();
                mc.ConfigSubjectModule();
                mc.ConfigTransactionModule();
                mc.ConfigUserModule();
                mc.ConfigWalletModule();
            });
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
