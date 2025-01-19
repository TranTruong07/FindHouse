using FindHouseAndT.Application.ExternalInterface;
using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Application.Services;
using FindHouseAndT.Application.UnitOfWork;
using FindHouseAndT.Application.UseCase;
using FindHouseAndT.Infrastructure.Data.MailService;
using FindHouseAndT.Infrastructure.Data.Repositories;
using FindHouseAndT.Infrastructure.Data.UnitOfWork;
using FindHouseAndT.Infrastructure.ExternalServices;
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


            // UseCase Motel
            services.AddScoped<ICreateMotelUseCase,  CreateMotelUseCase>();
			services.AddScoped<IGetMotelByIdUseCase, GetMotelByIdUseCase>();
			services.AddScoped<IGetAllMotelUseCase, GetAllMotelUseCase>();
			services.AddScoped<IUpdateMotelUseCase, UpdateMotelUseCase>();

			// UseCase Room
			services.AddScoped<ICreateNewRoomUseCase,  CreateNewRoomUseCase>();
            services.AddScoped<IGetAllRoomsByMotelIdUseCase,  GetAllRoomsByMotelIdUseCase>();
            services.AddScoped<IGetRoomByRoomCodeAndIdMotelUseCase, GetRoomByRoomCodeAndIdMotelUseCase>();
            services.AddScoped<IUpdateRoomUseCase, UpdateRoomUseCase>();
            services.AddScoped<IGetRoomByIdUseCase, GetRoomByIdUseCase>();

            // UseCase BookRequest
            services.AddScoped<ICreateBookRequestUseCase,  CreateBookRequestUseCase>();
            services.AddScoped<IGetBookRequestByCustomerIdUseCase, GetBookRequestByCustomerIdUseCase>();
            services.AddScoped<IGetAllBookRequestUseCase, GetAllBookRequestUseCase>();
            services.AddScoped<IGetBookRequestByIdUseCase, GetBookRequestByIdUseCase>();
            services.AddScoped<IUpdateBookRequestUseCase, UpdateBookRequestUseCase>();

			// Service
			services.AddScoped<IMotelService, MotelService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IFileStorageService, AWSFileStorageService>();
            services.AddTransient<IMailService, MailService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IBookRequestService, BookRequestService>();

            //repository
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserAppRepository, UserAppRepository>();
            services.AddScoped<IMotelRepository, MotelRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IHouseOwnerRepository, HouseOwnerRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IBookRequestRepository, BookRequestRepository>();
            return services;
        }
    }
}
