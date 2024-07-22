using mousse.Domain.Users;

namespace mousse.Persistence.Users;

public class UserRepository(MousseContext context)
    : Repository<User>(context), IUserRepository
{
}
