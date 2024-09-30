using Domain.Errors;

namespace mousse.Domain.Users.Emails;

public static class EmailErrors
{
    public static Error TooLong = new Error(
        "Email.TooLong", "The email is too long.");

    public static Error InvalidFormat = new Error(
        "Email.InvalidFormat", "The email contains unacceptable symbols.");
}
