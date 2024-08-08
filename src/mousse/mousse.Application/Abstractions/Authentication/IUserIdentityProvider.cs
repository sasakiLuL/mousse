namespace mousse.Application.Abstractions.Authentication;

public interface IUserIdentityProvider
{
    Guid GetUserId();
}
