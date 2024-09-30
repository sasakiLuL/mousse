using Application.Data;
using Application.Messaging;
using Dapper;
using Domain.Results;
using Modules.Users.Domain.Users;
using System.Data;

namespace Modules.Users.Application.Users.GetById;

public class GetUserByIdQueryHandler(IDbConnectionFactory factory) : IQueryHandler<GetUserByIdQuery, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        using IDbConnection connection = factory.GetOpenConnection();

        UserResponse? user = await connection.QueryFirstOrDefaultAsync<UserResponse>(
            """
            SELECT
                u.user_id AS UserId,
                u.email AS Email,
                u.user_name AS UserName
            FROM users.users u
            WHERE u.user_id = @UserId
            """, new { request.UserId });

        if (user is null)
        {
            return Result.Failure<UserResponse>(UserErrors.NotFound(request.UserId));
        }

        return user;
    }
}
