using DAL.EF;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repos
{
    public class OrderRepo
    {
        SismsSp26Context db;
        public OrderRepo(SismsSp26Context db) { this.db = db; }
        public bool Create(Order o) { db.Orders.Add(o); return db.SaveChanges() > 0; }
        public bool CreateItem(OrderItem oi) { db.OrderItems.Add(oi); return db.SaveChanges() > 0; }
        public Order Get(int id) { return db.Orders.Find(id); }
        public Order GetWithItems(int id) { return db.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).Include(o => o.Customer).FirstOrDefault(o => o.Id == id); }
        public List<Order> Get() { return db.Orders.Include(o => o.Customer).OrderByDescending(o => o.OrderDate).ToList(); }
        public List<OrderItem> GetItemsByOrder(int orderId) { return db.OrderItems.Include(i => i.Product).Where(i => i.OrderId == orderId).ToList(); }
        public bool Update(Order o) { var ex = Get(o.Id); db.Entry(ex).CurrentValues.SetValues(o); return db.SaveChanges() > 0; }
    }
}
