using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PhoneBook.Application.Contracts.BaseRepositories;
using PhoneBook.Application.Contracts.CallHistories;
using PhoneBook.Application.Contracts.Contacts;
using PhoneBook.Application.Contracts.Groups;
using PhoneBook.Application.DTOs.Contacts;
using PhoneBook.Infra;
using PhoneBook.Infra.Repositories;
using PhoneBook.Identity;
using PhoneBook.Identity.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add User Secret
builder.Configuration.AddUserSecrets("be12b960-bb41-4af9-98d2-8f11fdc978e4");

// Services
//builder.Services.ConfigureApplicationServices();
//builder.Services.ConfigureIdentityServices(builder.Configuration);
//builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblies(typeof(ContactDto).Assembly));

//Add DbContexts
builder.Services.AddDbContext<PhoneBookIdentityDbContext>(c=>c.UseSqlServer(builder.Configuration["ConnectionStrings:cnn1"]));
builder.Services.AddDbContext<PhoneBookDbContext>(c => c.UseSqlServer(builder.Configuration["ConnectionStrings:cnn2"]));

// Add Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(c =>
{
    c.Password.RequiredLength = 8;
    c.Password.RequireNonAlphanumeric = true;
    c.Password.RequireUppercase = true;
    c.Password.RequireDigit = false;

}).AddEntityFrameworkStores<PhoneBookIdentityDbContext>();

// Repositories
builder.Services.AddScoped<ICallHistoryRepository, CallHistoryRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IGroupRepository, GroupRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
