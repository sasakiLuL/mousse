using mousse.Domain.Core.Errors;

namespace mousse.Domain.Tags.TagNames;

public static class TagNameErrors
{
    public static Error TooLong = new Error(
            "TagName.TooLong", "The name of tag is too long.");

    public static Error InvalidFormat = new Error(
        "TagName.InvalidFormat", "The name of tag contains unacceptable symbols.");
}
