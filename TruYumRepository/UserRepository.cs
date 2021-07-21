using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruYumRepository
{
    public class UserRepository : IUserRepository
    {
        TruYumDataContext dc = new TruYumDataContext();
        public async Task InsertUser(User user)
        {
            await dc.Users.AddAsync(user);
            await dc.SaveChangesAsync();
        }
        public async Task<bool> ValidateUser(string userId, string pwd)
        {
            try
            {
                User user = await (from u in dc.Users where u.UserId == userId && u.UserPassword == pwd select u).FirstAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
