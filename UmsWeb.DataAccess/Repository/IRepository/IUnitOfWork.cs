using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmsWeb.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public CourseRepository CourseRepository { get; }
        public DepartmentRepository Department { get; }
        public FeesRepository Fees { get; }
        public StudentRepository Students { get; }
        public SubjectRepository Subjects { get; }
        public TeacherRepository Teachers { get; }
        public UserRepository Users { get; }
        void Save();

    }
}
