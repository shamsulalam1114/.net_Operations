using DAL.EF;
using DAL.EF.Tables;
namespace DAL.Repos
{
    public class CustomerRepo
    {
        SismsSp26Context db;
        public CustomerRepo(SismsSp26Context db) { this.db = db; }
        public bool Create(Customer c) { db.Customers.Add(c); return db.SaveChanges() > 0; }
        public Customer Get(int id) { return db.Customers.Find(id); }
        public List<Customer> Get() { return db.Customers.ToList(); }
        public bool Update(Customer c) { var ex = Get(c.Id); db.Entry(ex).CurrentValues.SetValues(c); return db.SaveChanges() > 0; }
        public bool Delete(int id) { var ex = Get(id); db.Customers.Remove(ex); return db.SaveChanges() > 0; }
    }
}
