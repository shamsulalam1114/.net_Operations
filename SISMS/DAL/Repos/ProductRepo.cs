using DAL.EF;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repos
{
    public class ProductRepo
    {
        SismsSp26Context db;
        public ProductRepo(SismsSp26Context db) { this.db = db; }
        public bool Create(Product p) { db.Products.Add(p); return db.SaveChanges() > 0; }
        public Product Get(int id) { return db.Products.Find(id); }
        public List<Product> Get() { return db.Products.ToList(); }
        public List<Product> GetWithCategory() { return db.Products.Include(p => p.CidNavigation).ToList(); }
        public bool Update(Product p) { var ex = Get(p.Id); db.Entry(ex).CurrentValues.SetValues(p); return db.SaveChanges() > 0; }
        public bool Delete(int id) { var ex = Get(id); db.Products.Remove(ex); return db.SaveChanges() > 0; }
    }
}
