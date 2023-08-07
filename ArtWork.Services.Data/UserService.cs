
namespace ArtStroke.Services.Data
{
    using ArtStroke.Data;
    using ArtStroke.Data.Models;
    using ArtStroke.Services.Data.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {
        private readonly ArtStrokeDbContext dbContext;
        public UserService(ArtStrokeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<string> GetFullNameByEmailAsync(string email)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
