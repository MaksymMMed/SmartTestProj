using Hangfire;
using Microsoft.AspNetCore.Identity;
using SmartTestProj.API.Extensions;
using SmartTestProj.BLL.BackgroundService;
using SmartTestProj.BLL.BackgroundServices;
using SmartTestProj.BLL.Services.Interfaces;
using SmartTestProj.BLL.Services.Realizations;
using SmartTestProj.DAL.Context;
using SmartTestProj.DAL.Repository.Interface;
using SmartTestProj.DAL.Repository.Realization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSqlServer<AppDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddScoped<IEquipmentPlacementContractRepository, EquipmentPlacementContractRepository>();
builder.Services.AddScoped<IProductionFacilityRepository, ProductionFacilityRepository>();
builder.Services.AddScoped<IProcessEquipmentTypeRepository, ProcessEquipmentTypeRepository>();

builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IEquipmentPlacementContractService, EquipmentPlacementContractService>();
builder.Services.AddTransient<IProductionFacilityService, ProductionFacilityService>();
builder.Services.AddTransient<IProcessEquipmentTypeService, ProcessEquipmentTypeService>();

builder.Services.AddTransient<LoggingService>();

builder.Services.AddSingleton<IBackgroundJobService,HangfireBackgroundJobService>();

builder.Services.AddIdentityCore<IdentityUser>()
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddTokenInSwagger();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAnyOrigin", builder =>
//    {
//        builder.AllowAnyOrigin()
//            .AllowAnyMethod()
//            .AllowAnyHeader();
//    });
//});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddHangfire((_, config) =>
{
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddHangfireServer();

var app = builder.Build();

app.CreateUser();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
    
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
