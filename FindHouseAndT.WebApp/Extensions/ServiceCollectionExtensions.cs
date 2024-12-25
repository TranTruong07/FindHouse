using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Application.Services;
using FindHouseAndT.Application.Services.Common;
using FindHouseAndT.Application.UnitOfWork;
using FindHouseAndT.Application.UseCase;
using FindHouseAndT.Application.UseCase.Implement.Common;
using FindHouseAndT.Application.UseCase.Interface.HouseOwner;
using FindHouseAndT.Application.UseCase.Interface.UserApp;
using FindHouseAndT.Infrastructure.Data.MailService;
using FindHouseAndT.Infrastructure.Data.Repositories;
using FindHouseAndT.Infrastructure.Data.UnitOfWork;
using FindHouseAndT.Models.MailKit;

namespace FindHouseAndT.WebApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //UseCase (User)
            services.AddScoped<IGetCustomerUseCase, GetCustomerUseCase>();
            services.AddScoped<IRegisCustomerUseCase, RegisCustomerUseCase>();
            services.AddScoped<IRegisHouseOwnerUseCase, RegisHouseOwnerUseCase>();
            services.AddScoped<IRegisUserAppUseCase, RegisUserAppUseCase>();
            services.AddScoped<IGetMotelByIdUseCase, GetMotelByIdUseCase>();
            services.AddScoped<IUpdateCustomerUseCase, UpdateCustomerUseCase>();

            // UseCase Common
            services.AddScoped<IAWSUploadImageUseCase, AWSUploadImageUseCase>();
            services.AddScoped<IGetPreSignedUrlUseCase, GetPreSignedUrlUseCase>();

            // Service
            services.AddScoped<MotelService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<AWSService>();
            services.AddTransient<IMailService, MailService>();

            //repository
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserAppRepository, UserAppRepository>();
            services.AddScoped<IMotelRepository, MotelRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IHouseOwnerRepository, HouseOwnerRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            return services;
        }
    }
}
