using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmsWeb.DataAccess.Repository.IRepository;
using UmsWeb.Models;

namespace UmsWeb.DataAccess.Repository
{
    public class TeacherRepository : Repository<Teacher>,ITeacherRepository
    {
        private readonly ApplicationDbContext _db;
        public TeacherRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Teacher teach)
        {
            var obj = _db.Teachers.FirstOrDefault(x => x.Id == teach.Id);   
            if(obj!=null)
            {
                obj.Name = teach.Name;
                obj.Address = teach.Address;
                obj.Email = teach.Email;
                obj.DOB = teach.DOB;
                obj.DOJ = teach.DOJ;
                obj.Phone = teach.Phone;
            }
        }
    }
}
