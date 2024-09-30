using Domain.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modules.Users.Application.Followers.Unfollow;

namespace mousse.Api.Endpoints.Users.Unfollow;

public class UnfollowEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(
            $"{UsersConstants.Routes.Base}/{UsersConstants.Routes.Unfollow}",
            async ([FromRoute] Guid userId, [FromRoute] Guid followedId, ISender sender, CancellationToken token) =>
            {
                var command = new UnfollowCommand(userId, followedId);

                var result = await sender.Send(command, token);

                return result.Match(
                    () => Results.NoContent(),
                    (errors) => Results.NotFound(errors));
            })
            .RequireAuthorization()
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithTags(UsersConstants.FollowersTag);
    }
}
