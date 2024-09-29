namespace Application.Authentication;

public interface IUserCredentialsProvider
{
    Guid UserId { get; }
}
