using Bussines.Implements;
using Bussines.Interface;
using Data.Implements;
using Data.Interface;
using Entity.Model.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContexts>();
builder.Services.AddScoped<IBPerson, BPerson>();
builder.Services.AddScoped<IDPerson, DPerson>();
builder.Services.AddScoped<IBRole, BRole>();
builder.Services.AddScoped<IDRole, DRole>();
builder.Services.AddScoped<IBView, BView>();
builder.Services.AddScoped<IDView, DView>();
builder.Services.AddScoped<IBUser, BUser>();
builder.Services.AddScoped<IDUser, DUser>();
builder.Services.AddScoped<IBModule, BModule>();
builder.Services.AddScoped<IDModule, DModule>();
builder.Services.AddScoped<IBRole_View, BRole_View>();
builder.Services.AddScoped<IDRole_View, DRole_View>();
builder.Services.AddScoped<IBUser_role, BUser_role>();
builder.Services.AddScoped<IDUser_role, DUser_role>();

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
