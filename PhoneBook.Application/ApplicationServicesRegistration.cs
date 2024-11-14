using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Application.DTOs.Contact.Validators;
using PhoneBook.Application.DTOs.Contact;
using PhoneBook.Application.Features.Contacts.Requests.Queries;
using Microsoft.AspNetCore.Mvc;


namespace PhoneBook.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            // Inject MediatR
            services.AddMediatR(c => c.RegisterServicesFromAssemblies(typeof(ApplicationServicesRegistration).Assembly));

            // Config AutoMapper
            services.AddAutoMapper(typeof(GetAllContactsRequest).Assembly);

            // Fluent Validation
            services.AddScoped<IValidator<CreateContactDto>, CreateContactValidator>();

            // Configs
            services.Configure<JsonOptions>(x =>
            {
                x.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            });
        }
    }
}
