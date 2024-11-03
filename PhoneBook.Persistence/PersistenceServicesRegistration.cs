//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using PhoneBook.Application.Contracts.BaseRepositories;
//using PhoneBook.Application.Contracts.CallHistories;
//using PhoneBook.Application.Contracts.Contacts;
//using PhoneBook.Application.Contracts.Groups;
//using PhoneBook.Infra.Data.Repositories;

//namespace PhoneBook.Infra.Data
//{
//    public static class PersistenceServicesRegistration
//    {
//        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
//            IConfiguration configuration)
//        {
//            // DbContext
//            services.AddDbContext<PhoneBookDbContext>(options =>
//            {
//                options.UseSqlServer(configuration
//                    .GetConnectionString("cnn2"));
//            });


//            // Repositories
//            services.AddScoped<ICallHistoryRepository, CallHistoryRepository>();
//            services.AddScoped<IContactRepository, ContactRepository>();
//            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//            services.AddScoped<IGroupRepository, GroupRepository>();

//            return services;
//        }
//    }
//}
