using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmsWeb.Models;
using UmsWeb.Models.ViewModels;

namespace UmsWeb.DataAccess.Repository.IRepository
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        public void Update(Teacher teach);
    }
}
