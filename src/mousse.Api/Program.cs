using Infrastructure;
using Modules.Users.Application;
using Modules.Users.Domain;
using Modules.Users.Infrastructure;
using Modules.Users.Persistence;
using mousse.Api.Extensions;
using Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);

builder.Services.AddCommonInfrastructure(builder.Configuration);

builder.Services.AddCommonPersistence(builder.Configuration);

builder.Services.AddUsersDomain();

builder.Services.AddUsersApplication();

builder.Services.AddUsersPersistence();

builder.Services.AddUsersInfrastructure();

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerWithAuth();

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapEndpoints();

if (app.Environment.IsDevelopment())
{
    //app.ApplyMigrations<UsersDbContext>();

    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();