using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmsWeb.Models;

namespace UmsWeb.DataAccess.Repository.IRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        public void Update(Course course);
    }
}
