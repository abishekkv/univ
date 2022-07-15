using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmsWeb.Models;

namespace UmsWeb.DataAccess.Repository.IRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        public void Update(Student stud);
    }
}
