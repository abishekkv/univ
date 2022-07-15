using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmsWeb.DataAccess.Repository.IRepository;
using UmsWeb.Models;

namespace UmsWeb.DataAccess.Repository
{
    public class StudentRepository : Repository<Student>,IStudentRepository
    {
        private readonly ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Models.Student stud)
        {
            var obj = _db.Students.FirstOrDefault(x => x.Id == stud.Id);
            if (obj != null)
            {
                obj.Name = stud.Name;
                obj.Address = stud.Address;
                obj.Email = stud.Email;
                obj.DOB = stud.DOB;
                obj.FatherName = stud.FatherName;
                obj.MotherName = stud.MotherName;
                obj.Semester = stud.Semester;
                obj.Sex = stud.Sex;
                obj.YearOfJoining = stud.YearOfJoining;
            }
        }
    }
}
