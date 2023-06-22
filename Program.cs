using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using ODataFilterEnumExample.Dtos;
using ODataFilterEnumExample.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = new MapperConfiguration(cfg =>
{
    //Configuring Employee and EmployeeDTO
    cfg.CreateMap<Customer, CustomerDto>();
    cfg.CreateMap<CustomerType, CustomerTypeDto>();
    //Any Other Mapping Configuration ....
});
//Create an Instance of Mapper and return that Instance
IMapper mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

ODataConventionModelBuilder emd = new();
emd.EntitySet<CustomerDto>("Customers");

builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("odata", emd.GetEdmModel()).Filter().Select().Expand());

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
