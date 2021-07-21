using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruYumRepository
{
    public interface IMenuItemRepository
    {
        Task<List<MenuItem>> GetAllMenuItems();
        Task<MenuItem> GetMenuItemById(int id);
        Task<List<MenuItem>> GetMenuItemsByCategory(string catName);
        Task InsertMenuItem(MenuItem menuItem);
        Task UpdateMenuItem(int id, MenuItem menuItem);
        Task DeleteMenuItem(int id);
    }
}
