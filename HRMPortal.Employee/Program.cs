using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using HRMPortal.Employee.DBContext;
using HRMPortal.Employee.Engine;
using HRMPortal.Employee.Engine.@class;
using HRMPortal.Employee.Engine.Class;
using HRMPortal.Employee.Engine.Interface;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.ErrorHandling;
using HRMPortal.Employee.Model.AddressModel;
using HRMPortal.Employee.Model.PreviousExprience;
using HRMPortal.Employee.Model.SalaryModel;
using HRMPortal.Employee.Models;
using HRMPortal.Employee.Processor;
using HRMPortal.Employee.Processor.Class;
using HRMPortal.Employee.Processor.Interface;
using HRMPortal.Employee.Repository;
using HRMPortal.Employee.Repository.Class;
using HRMPortal.Employee.Repository.Interface;
using HRMPortal.Employee.Validation;
using HRMPortal.Employee.Validator;
using HRMPortal.Employee.Validators;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static HRMPortal.Employee.Extentions.DateOnlyConverter;
using static HRMPortal.Employee.Validator.SalaryValidator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//salary
builder.Services.AddScoped<ISalaryProcessor, SalaryProcessor>();
builder.Services.AddScoped<ISalaryEngine, SalaryEngine>();
builder.Services.AddScoped<ISalaryRepository, SalaryRepository>();

//address
builder.Services.AddScoped<IAddressProcessor, AddressProcessor>();
builder.Services.AddScoped<IAddressEngine, AddressEngine>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

//Leave
builder.Services.AddScoped<ILeaveProcess, LeaveProcess>();
builder.Services.AddScoped<ILeaveEngine, LeaveEngine>();
builder.Services.AddScoped<IleaveRepository, LeaveRepository>();

//Employee
builder.Services.AddScoped<IEmployeeProcessor, EmployeeProcessor>();
builder.Services.AddScoped<IEmployeeEngine, EmployeeEngine>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

//PreviousExprience
builder.Services.AddScoped<IPreviousExprienceProcessor, PreviousExprienceProcessor>();
builder.Services.AddScoped<IPreviousExprienceEngine, PreviousExprienceEngine>();
builder.Services.AddScoped<IPreviousExprienceRepository, PreviousExprienceRepository>();

//LeaveBalance
builder.Services.AddScoped<ILeaveBalanceRepository, LeaveBalanceRepository>();
builder.Services.AddScoped<ILeaveBalanceEngine, LeaveBalanceEngine>();
builder.Services.AddScoped<ILeaveBalancePrecessor, LeaveBalanceProcessor>();

builder.Services.AddScoped<IBankProcessor, BankProcessor>();
builder.Services.AddScoped<IBankEngine, BankEngine>();
builder.Services.AddScoped<IBankRepository, BankRepository>();

builder.Services.AddScoped<IEducationProcessor, EducationProcessor>();
builder.Services.AddScoped<IEducationEngine, EducationEngine>();
builder.Services.AddScoped<IEducationRepository, EducationRepository>();



//for fluent validatio 
builder.Services.AddTransient<IValidator<SalaryAddUpdateDto>, SalaryValidator>();
builder.Services.AddTransient<IValidator<AddressDto>, AddressValidator>();
builder.Services.AddTransient<IValidator<PreviousExprienceAddDto>, PreviousExprienceValidator>();
builder.Services.AddTransient<IValidator<EmployeeAddDto>, EmployeeAddValidation>();
builder.Services.AddTransient<IValidator<EmployeeUpdateDto>, EmployeeUpdateValidation>();
builder.Services.AddTransient<IValidator<LeaveUpdateModel>, LeaveUpdateModelValidation>();
builder.Services.AddTransient<IValidator<LeaveAddModel>, LeaveAddModelValidation>();


builder.Services.AddControllers(option =>
{
	option.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
		 .AddXmlDataContractSerializerFormatters().AddJsonOptions(options =>
         {
			 options.JsonSerializerOptions.Converters.Add(new JSONHelper());
		 }).AddFluentValidation();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*builder.Services.AddValidatorsFromAssemblyContaining<>();*/

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<HRMPortalEmployeeContext>(
    DbContextOptions => DbContextOptions.UseSqlServer(
        builder.Configuration["ConnectionString:HRMPoratalEmployeeDBConnectionString"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();

app.UseRouting();

//app.UseAuthentication();

app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
