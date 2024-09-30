using Application.Data;
using Application.Messaging;
using Dapper;
using Domain.Results;
using Modules.Users.Domain.Users;
using System.Data;

namespace Modules.Users.Application.Followers.GetByUserId;

public class GetFollowersByUserIdQueryHandler(
    IUserRepository userRepository,
    IDbConnectionFactory connectionFactory) : IQueryHandler<GetFollowersByUserIdQuery, List<FollowerResponse>>
{
    public async Task<Result<List<FollowerResponse>>> Handle(GetFollowersByUserIdQuery request, CancellationToken token)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, token);

        if (user is null)
        {
            return Result.Failure<List<FollowerResponse>>(UserErrors.NotFound(request.UserId));
        }

        using IDbConnection connection = connectionFactory.GetOpenConnection();

        var response = await connection.QueryAsync<FollowerResponse>(
            """
            SELECT
            	u.user_id as FollowerId,
            	u.user_name as UserName,
            	f.created_on_utc as FollowedOnUtc 
            FROM users.followers f INNER JOIN users.users u ON u.user_id = f.followed_id 
            WHERE f.user_id = @UserId
            """, new { request.UserId });

        return Result.Success(response.ToList());
    }
}
