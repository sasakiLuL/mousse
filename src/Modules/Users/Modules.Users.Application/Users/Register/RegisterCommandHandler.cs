using Application.Authentication;
using Application.Data;
using Application.Messaging;
using Domain.Results;
using Modules.Users.Application.Abstractions;
using Modules.Users.Domain.Users;
using Modules.Users.Domain.Users.Emails;
using mousse.Domain.Users.UserNames;

namespace Modules.Users.Application.Users.Register;

public class RegisterCommandHandler(
    IUserRepository userRepository,
    IUserCredentialsProvider userCredentialsProvider,
    IIdentityService identityProviderService,
    IUnitOfWork unitOfWork) : ICommandHandler<RegisterCommand>
{
    public async Task<Result> Handle(RegisterCommand request, CancellationToken token)
    {
        var email = Email.Create(request.Email);

        var userName = UserName.Create(request.UserName);

        var validationResult = Result.AllFailuresOrSuccess(email, userName);

        if (validationResult.IsFailure)
        {
            return validationResult;
        }

        var isExistResult = await identityProviderService.ExistsAsync(
            userCredentialsProvider.UserId.ToString(), token);

        if (!isExistResult)
        {
            return Result.Failure(UserErrors.InvalidUserCredentials);
        }

        var user = User.Create(Guid.NewGuid(), userCredentialsProvider.UserId, email.Value, userName.Value);

        await userRepository.AddAsync(user, token);

        await unitOfWork.SaveChangesAsync(token);

        return Result.Success();
    }
}
