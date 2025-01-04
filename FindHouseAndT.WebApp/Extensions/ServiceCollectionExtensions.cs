using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Application.Services;
using FindHouseAndT.Application.UnitOfWork;
using FindHouseAndT.Application.UseCase;
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
            services.AddScoped<IUpdateCustomerUseCase, UpdateCustomerUseCase>();

            // UseCase Common
            services.AddScoped<IAWSUploadImageUseCase, AWSUploadImageUseCase>();
            services.AddScoped<IGetPreSignedUrlUseCase, GetPreSignedUrlUseCase>();
            services.AddScoped<IUpdateMotelUseCase, UpdateMotelUseCase>();


            // UseCase Motel
            services.AddScoped<ICreateMotelUseCase,  CreateMotelUseCase>();
			services.AddScoped<IGetMotelByIdUseCase, GetMotelByIdUseCase>();
			services.AddScoped<IGetAllMotelUseCase, GetAllMotelUseCase>();

            // UseCase Room
            services.AddScoped<ICreateNewRoomUseCase,  CreateNewRoomUseCase>();
            services.AddScoped<IGetAllRoomsByMotelIdUseCase,  GetAllRoomsByMotelIdUseCase>();
            services.AddScoped<IGetRoomByRoomCodeUseCase, GetRoomByRoomCodeUseCase>();
            services.AddScoped<IUpdateRoomUseCase, UpdateRoomUseCase>();
            services.AddScoped<IGetRoomByIdUseCase, GetRoomByIdUseCase>();

            // UseCase BookRequest
            services.AddScoped<ICreateBookRequestUseCase,  CreateBookRequestUseCase>();
            services.AddScoped<IGetBookRequestByCustomerIdUseCase, GetBookRequestByCustomerIdUseCase>();

			// Service
			services.AddScoped<MotelService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<AWSService>();
            services.AddTransient<IMailService, MailService>();
            services.AddScoped<RoomService>();
            services.AddScoped<BookRequestService>();

            //repository
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserAppRepository, UserAppRepository>();
            services.AddScoped<IMotelRepository, MotelRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IHouseOwnerRepository, HouseOwnerRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IBookRequestRepository, BookRequestRepository>();
            return services;
        }
    }
}
