using AutoMapper;
using DataAccessLayer.CosmosClient;
using DataAccessLayer.Repository.Implementation;
using DataAccessLayer.Repository.@interface;
using ProgramAPI.CustomException;
using ProgramAPI.MappingProfile;
using ServiceLayer.ServiceImplementation;
using ServiceLayer.ServiceInterface;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
    .AddJsonFile("app" + "settings.json")
    .Build();


var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<ProgramMappingProfile>();
   
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<CustomExceptionFilterAttribute>();
//builder.Services.AddSingleton<IConfiguration>(Configuration);
builder.Services.AddSingleton<CosmosClientProvider>();


builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
builder.Services.AddScoped<IApplicationTemplateRepo, ApplicationTemplateRepository>();
builder.Services.AddScoped<IWorkFlowRepository, WorkFlowRepository>();
builder.Services.AddScoped<IProgramPreviewRepo, ProgramPreviewRepository>();

builder.Services.AddScoped<IProgramService, ProgramService>();
builder.Services.AddScoped<IApplicationTemplateService, ApplicationTemplateService>();
builder.Services.AddScoped<IWorkFlowService, WorkFlowService>();
builder.Services.AddScoped<IProgramPreviewService, ProgramPreviewService>();



builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();