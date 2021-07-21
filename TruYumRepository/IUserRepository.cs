using System.Threading.Tasks;

namespace TruYumRepository
{
    public interface IUserRepository
    {
        Task InsertUser(User user);
        Task<bool> ValidateUser(string userId, string pwd);
    }
}