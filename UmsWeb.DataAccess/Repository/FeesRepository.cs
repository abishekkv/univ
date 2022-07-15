using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmsWeb.DataAccess.Repository.IRepository;
using UmsWeb.Models;

namespace UmsWeb.DataAccess.Repository
{
    public class FeesRepository : Repository<Fees>,IFeesRepository
    {
        private readonly ApplicationDbContext _db;
        public FeesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Models.Fees fee)
        {
            _db.Fees.Update(fee);
        }
    }
}
