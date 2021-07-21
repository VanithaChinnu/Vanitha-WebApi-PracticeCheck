using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruYumRepository
{
    public class CartRepository : ICartRepository {
        TruYumDataContext dc = new TruYumDataContext();
        public async Task DeleteCart(int uid, int mid) {
            try {
                Cart cart2del = await GetCart(uid, mid);
                dc.Carts.Remove(cart2del);
                await dc.SaveChangesAsync();
            }
            catch (Exception ex) {
                throw new TruYumException(ex.Message);
            }
        }
        public async Task<List<Cart>> GetAllCarts() {
            return await dc.Carts.Include("MenuItem").ToListAsync();
        }
        public async Task<Cart> GetCart(int uid, int mid) {
            try {
                Cart cart = await (from c in dc.Carts where c.UserId == uid && c.MenuItemId == mid select c).FirstAsync();
                return cart;
            }
            catch {
                throw new TruYumException("No such menu item id with the given user id");
            }
        }
        public async Task<List<Cart>> GetItemsByUserId(int uid) {
            List<Cart> carts = await (from cart in dc.Carts where cart.UserId == uid select cart).ToListAsync();
            if (carts.Count == 0)
                throw new TruYumException("No such user id");
            else
                return carts;
        }
        public async Task<List<Cart>> GetItemsByMenuId(int mid) {
            List<Cart> carts = await (from cart in dc.Carts where cart.MenuItemId == mid select cart).ToListAsync();
            if (carts.Count == 0)
                throw new TruYumException("No such menuitem id");
            else
                return carts;
        }
        public async Task InsertCart(Cart cart) {
            try {
                await dc.Carts.AddAsync(cart);
                await dc.SaveChangesAsync();
            }
            catch (Exception ex) {
                throw new TruYumException(ex.Message);
            }
        }
        public async Task UpdateCart(int uid, int mid, Cart cart) {
            try {
                Cart cart2edit = await GetCart(uid, mid);
                cart2edit.Quantity = cart.Quantity;
                dc.SaveChanges();
            }
            catch (Exception ex) {
                throw new TruYumException(ex.Message);
            }
        }
    }
}
