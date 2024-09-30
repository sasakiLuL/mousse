using Domain.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modules.Users.Application.Followers.GetByUserId;

namespace mousse.Api.Endpoints.Users.GetFollowers;

public class GetFollowersEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
            $"{UsersConstants.Routes.Base}/{UsersConstants.Routes.Followers}",
            async ([FromRoute] Guid userId, ISender sender, CancellationToken token) =>
            {
                var query = new GetFollowersByUserIdQuery(userId);

                var result = await sender.Send(query, token);

                return result.Match(
                    () => Results.Ok(result.Value),
                    (error) => Results.NotFound(error));
            })
            .RequireAuthorization()
            .Produces(StatusCodes.Status200OK, typeof(FollowerResponse))
            .Produces(StatusCodes.Status404NotFound)
            .WithTags(UsersConstants.FollowersTag);
    }
}
