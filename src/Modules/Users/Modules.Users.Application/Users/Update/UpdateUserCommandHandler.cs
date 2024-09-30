using Application.Authentication;
using Application.Data;
using Application.Messaging;
using Domain.Results;
using Modules.Users.Application.Abstractions;
using Modules.Users.Domain.Users;
using mousse.Domain.Users.UserNames;

namespace Modules.Users.Application.Users.Update;

public class UpdateUserCommandHandler(
    IUserRepository userRepository, 
    IUserCredentialsProvider userCredentialsProvider, 
    IUnitOfWork unitOfWork) : ICommandHandler<UpdateUserCommand>
{
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken token)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, token);

        if (user is null)
        {
            return Result.Failure(UserErrors.NotFound(request.UserId));
        }

        if (user.IdentityServiceUserId != userCredentialsProvider.UserId)
        {
            return Result.Failure(UserErrors.InvalidPermissions);
        }

        var newUserNameResult = UserName.Create(request.UserName);

        if (newUserNameResult.IsFailure)
        {
            return newUserNameResult;
        }

        user.UserName = newUserNameResult.Value;

        await unitOfWork.SaveChangesAsync(token);

        return Result.Success();
    }
}
