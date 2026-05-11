using DAL.EF;
using DAL.EF.Tables;
namespace DAL.Repos
{
    public class CategoryRepo
    {
        SismsSp26Context db;
        public CategoryRepo(SismsSp26Context db) { this.db = db; }
        public bool Create(Category c) { db.Categories.Add(c); return db.SaveChanges() > 0; }
        public Category Get(int id) { return db.Categories.Find(id); }
        public List<Category> Get() { return db.Categories.ToList(); }
        public bool Update(Category c) { var ex = Get(c.Id); db.Entry(ex).CurrentValues.SetValues(c); return db.SaveChanges() > 0; }
        public bool Delete(int id) { var ex = Get(id); db.Categories.Remove(ex); return db.SaveChanges() > 0; }
    }
}
