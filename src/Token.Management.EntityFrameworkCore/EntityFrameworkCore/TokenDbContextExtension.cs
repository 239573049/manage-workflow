using Microsoft.EntityFrameworkCore;

namespace Token.Management.EntityFrameworkCore.EntityFrameworkCore;

public static class TokenDbContextExtension
{
    public static ModelBuilder ConfigurationToken(this ModelBuilder builder)
    {
        return builder;
    }
}
