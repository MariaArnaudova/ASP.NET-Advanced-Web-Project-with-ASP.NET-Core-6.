

using System.Security.Claims;

namespace ArtStroke.Web.Infrastructure.Extentions
{
    using System.Security.Claims;
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}
