using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private ApplicationDbContext db;
        public OrderDetailRepository(ApplicationDbContext db):base(db)
        {
            this.db = db;
        }

        public void Update(OrderDetail obj)
        {
            db.OrderDetails.Update(obj);
        }
    }
}
