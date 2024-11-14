using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Identity;
using PhoneBook.Identity.Models;

namespace PhoneBook.Infra.Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Add DbContext
            services.AddDbContext<PhoneBookIdentityDbContext>(c => c.UseSqlServer(configuration["ConnectionStrings:cnn1"]));

            // Add Identity
            services.AddIdentity<ApplicationUser, IdentityRole>(c =>
            {
                c.Password.RequiredLength = 8;
                c.Password.RequireNonAlphanumeric = true;
                c.Password.RequireUppercase = true;
                c.Password.RequireDigit = false;

            }).AddEntityFrameworkStores<PhoneBookIdentityDbContext>();

            return services;
        }
    }
}
