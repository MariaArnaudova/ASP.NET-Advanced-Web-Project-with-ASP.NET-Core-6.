
namespace ArtStroke.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using ArtStroke.Data;
    using ArtStroke.Data.Models;
    using ArtStroke.Services.Data.Interfaces;
    using System.Collections.Generic;
    using ArtStroke.Web.ViewModels.User;

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

        public async Task<string> GetFullNameByIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            List<UserViewModel> allUsers = new List<UserViewModel>();

            IEnumerable<UserViewModel> artists =
               await this.dbContext
                .Artists
                .Include(a => a.User)
                .Select(a => new UserViewModel()
                {
                    Email = a.User.Email,
                    FullName = a.User.FirstName + " " + a.User.LastName,
                    PhoneNumber = a.PhoneNumber,
                })
                .ToArrayAsync();

            allUsers.AddRange(artists);

            IEnumerable<UserViewModel> users =
                await this.dbContext.Users
                .Where(u => !this.dbContext.Artists.Any(a => a.UserId == u.Id))
                .Select(u => new UserViewModel()
                {
                    Email = u.Email,
                    FullName =  u.FirstName + " " + u.LastName,
                    PhoneNumber =  string.Empty
                })
                .ToArrayAsync();

            allUsers.AddRange(users);

            return allUsers;

        }
    }
}
