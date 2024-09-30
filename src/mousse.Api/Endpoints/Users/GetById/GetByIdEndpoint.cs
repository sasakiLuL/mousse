using Domain.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modules.Users.Application.Users.GetById;

namespace mousse.Api.Endpoints.Users.GetById;

public class GetByIdEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
            $"{UsersConstants.Routes.Base}/{UsersConstants.Routes.GetById}",
            async ([FromRoute] Guid id, ISender sender, CancellationToken token) =>
            {
                var query = new GetUserByIdQuery(id);

                var result = await sender.Send(query, token);

                return result.Match(
                    () => Results.Ok(result.Value),
                    Results.NotFound);
            })
            .RequireAuthorization()
            .Produces(StatusCodes.Status200OK, typeof(UserResponse))
            .Produces(StatusCodes.Status404NotFound)
            .WithTags(UsersConstants.UsersTag);
    }
}
