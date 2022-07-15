using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmsWeb.DataAccess.Repository.IRepository;
using UmsWeb.Models;

namespace UmsWeb.DataAccess.Repository
{
    public class DepartmentRepository : Repository<Department>,IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Models.Department department)
        {
            _db.Departments.Update(department);
        }
    }
}
