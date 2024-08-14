using Library.Application.Core.Abstractions.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Library.Infrastructure.Authentication
{
    /// <summary>
    /// Provides the identifier of the currently authenticated user.
    /// </summary>
    internal sealed class UserIdentifierProvider : IUserIdentifierProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserIdentifierProvider"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">The HTTP context accessor used to access the current user's claims.</param>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="httpContextAccessor"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the user identifier claim is not present.</exception>
        public UserIdentifierProvider(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor == null)
                throw new ArgumentNullException(nameof(httpContextAccessor));

            string userIdClaim = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? throw new InvalidOperationException("The user identifier claim is required.");

            UserId = new Guid(userIdClaim);
        }

        /// <summary>
        /// Gets the identifier of the currently authenticated user.
        /// </summary>
        public Guid UserId { get; }
    }
}
