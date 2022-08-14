using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private ApplicationDbContext db;
        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public int DecrementCount(ShoppingCart ShoppingCart, int count)
        {
            ShoppingCart.Count -= count;
            return ShoppingCart.Count;
        }

        public int IncrementCount(ShoppingCart ShoppingCart, int count)
        {
            ShoppingCart.Count += count;
            return ShoppingCart.Count;
        }
    }
    
}
