using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruYumRepository
{
    public class MenuItemRepository : IMenuItemRepository {
        TruYumDataContext dc = new TruYumDataContext();
        public async Task DeleteMenuItem(int id) {
            try {
                MenuItem item2del = await GetMenuItemById(id);
                dc.MenuItems.Remove(item2del);
                await dc.SaveChangesAsync();
            }
            catch (Exception ex) {
                throw new TruYumException(ex.Message);
            }
        }
        public async Task<List<MenuItem>> GetAllMenuItems() {
            return await dc.MenuItems.ToListAsync();
        }
        public async Task<MenuItem> GetMenuItemById(int id) {
            try {
                MenuItem menuItem = await (from item in dc.MenuItems where item.Id == id select item).FirstAsync();
                return menuItem;
            }
            catch {
                throw new TruYumException("No such menu item id");
            }
        }
        public async Task<List<MenuItem>> GetMenuItemsByCategory(string catName) {
            List<MenuItem> menuItems = await (from item in dc.MenuItems where item.CategoryName == catName select item).ToListAsync();
            if (menuItems.Count == 0)
                throw new TruYumException("No such category id");
            else
                return menuItems;
        }
        public async Task InsertMenuItem(MenuItem menuItem) {
            try {
                await dc.MenuItems.AddAsync(menuItem);
                await dc.SaveChangesAsync();
            }
            catch (Exception ex) {
                throw new TruYumException(ex.Message);
            }
        }
        public async Task UpdateMenuItem(int id, MenuItem menuItem) {
            try {
                MenuItem item2edit = await GetMenuItemById(id);
                item2edit.Name = menuItem.Name;
                item2edit.Price = menuItem.Price;
                item2edit.Active = menuItem.Active;
                item2edit.DateOfLaunch = menuItem.DateOfLaunch;
                item2edit.FreeDelivery = menuItem.FreeDelivery;
                item2edit.CategoryName = menuItem.CategoryName;
                await dc.SaveChangesAsync();
            }
            catch (Exception ex) {
                throw new TruYumException(ex.Message);
            }
        }
    }

}
