using Application;
using FluentValidation.AspNetCore;
using Infrastructure;
using NWTools.Configurations;
using NWTools.ServiceBuilders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.AddConfigurations();

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);
builder.Services.AddApplication();
GraphQLServiceBuilder.Register(builder.Services, builder.Environment);
//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi3();

await app.Services.InitializeDatabasesAsync();

app.UseInfrastructure(builder.Configuration);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseWebSockets();
app.MapEndpoints();
app.MapGraphQL();

app.MapControllers();

app.Run();

