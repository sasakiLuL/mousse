using Domain.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modules.Users.Application.Followers.Follow;

namespace mousse.Api.Endpoints.Users.Follow;

public class FollowEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
            $"{UsersConstants.Routes.Base}/{UsersConstants.Routes.Follow}",
            async ([FromRoute] Guid userId, [FromRoute] Guid followedId, ISender sender, CancellationToken token) =>
            {
                var command = new FollowCommand(userId, followedId);

                var result = await sender.Send(command, token);

                return result.Match(
                    () => Results.Created(),
                    (errors) => Results.NotFound(errors));
            })
            .RequireAuthorization()
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status404NotFound)
            .WithTags(UsersConstants.FollowersTag);
    }
}
