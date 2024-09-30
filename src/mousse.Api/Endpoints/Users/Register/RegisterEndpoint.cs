using Domain.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modules.Users.Application.Users.Register;

namespace mousse.Api.Endpoints.Users.Register;

public class RegisterEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {

        app.MapPost(
            $"{UsersConstants.Routes.Base}/{UsersConstants.Routes.Register}",
            async ([FromBody] RegisterRequest request, ISender sender, HttpContext context, CancellationToken token) =>
            {
                var registerUserCommand = new RegisterCommand(
                    request.Email,
                    request.UserName);

                var result = await sender.Send(registerUserCommand, token);

                return result.Match(Results.Created, (errors) => Results.BadRequest(errors));
            })
            .RequireAuthorization()
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status401Unauthorized)
            .WithTags(UsersConstants.UsersTag);
    }
}
