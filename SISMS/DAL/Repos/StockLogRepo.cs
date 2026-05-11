using DAL.EF;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repos
{
    public class StockLogRepo
    {
        SismsSp26Context db;
        public StockLogRepo(SismsSp26Context db) { this.db = db; }
        public bool Create(StockLog s) { db.StockLogs.Add(s); return db.SaveChanges() > 0; }
        public List<StockLog> Get() { return db.StockLogs.Include(s => s.Product).OrderByDescending(s => s.CreatedAt).ToList(); }
    }
}
