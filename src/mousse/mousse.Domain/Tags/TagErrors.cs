using mousse.Domain.Core.Errors;

namespace mousse.Domain.Tags;

public static class TagErrors
{
    public static Error NotFound = new Error(
        "Tag.NotFound", "The tag with specified id was not found.");
}
