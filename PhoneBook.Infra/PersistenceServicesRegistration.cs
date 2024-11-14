using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Application.Contracts.Contacts;
using PhoneBook.Application.Contracts.Groups;
using PhoneBook.Infra.Repositories;

namespace PhoneBook.Infra.Data
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            //Add DbContext
            services.AddDbContext<PhoneBookDbContext>(c => c.UseSqlServer(configuration["ConnectionStrings:cnn2"]));

            // Repositories
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();

            return services;
        }
    }
}
