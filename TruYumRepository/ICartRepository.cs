using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruYumRepository
{
    public interface ICartRepository
    {
        Task<List<Cart>> GetAllCarts();
        Task<List<Cart>> GetItemsByUserId(int uid);
        Task<List<Cart>> GetItemsByMenuId(int mid);
        Task<Cart> GetCart(int uid, int mid);
        Task InsertCart(Cart cart);
        Task UpdateCart(int uid, int mid, Cart cart);
        Task DeleteCart(int uid, int mid);
    }
}
