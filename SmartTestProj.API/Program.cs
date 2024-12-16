using SmartTestProj.BLL.Services.Interfaces;
using SmartTestProj.BLL.Services.Realizations;
using SmartTestProj.DAL.Context;
using SmartTestProj.DAL.Repository.Interface;
using SmartTestProj.DAL.Repository.Realization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<AppDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddScoped<IEquipmentPlacementContractRepository, EquipmentPlacementContractRepository>();
builder.Services.AddScoped<IProductionFacilityRepository, ProductionFacilityRepository>();
builder.Services.AddScoped<IProcessEquipmentTypeRepository, ProcessEquipmentTypeRepository>();


builder.Services.AddTransient<IEquipmentPlacementContractService, EquipmentPlacementContractService>();
builder.Services.AddTransient<IProductionFacilityService, ProductionFacilityService>();
builder.Services.AddTransient<IProcessEquipmentTypeService, ProcessEquipmentTypeService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
