//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using PhoneBook.Infra.Identity.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using PhoneBook.Infra.Data;

//namespace PhoneBook.Infra.Identity
//{
//    public static class IdentityServicesRegistration
//    {
//        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services,
//            IConfiguration configuration)
//        {
//            // Add DbContext
//            services.AddDbContext<PhoneBookDbContext>(options =>
//            {
//                options.UseSqlServer(configuration
//                    .GetConnectionString("cnn1"));
//            });

//            return services;
//        }
//    }
//}
