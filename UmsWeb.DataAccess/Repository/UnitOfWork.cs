using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmsWeb.DataAccess.Repository.IRepository;

namespace UmsWeb.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _unitOfWork;
        public CourseRepository CourseRepository { get; private set; }
        public DepartmentRepository Department { get; private set; }
        public FeesRepository Fees { get; private set; }
        public StudentRepository Students { get; private set; }
        public SubjectRepository Subjects { get; private set; }
        public TeacherRepository Teachers { get; private set; }
        public UserRepository Users { get; private set; }

        public UnitOfWork(ApplicationDbContext unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CourseRepository = new CourseRepository(_unitOfWork);
            Department = new DepartmentRepository(_unitOfWork);
            Fees = new FeesRepository(_unitOfWork);
            Students = new StudentRepository(_unitOfWork);
            Teachers = new TeacherRepository(_unitOfWork);
            Subjects = new SubjectRepository(_unitOfWork);
            Teachers = new TeacherRepository(_unitOfWork);
            Users = new UserRepository(_unitOfWork);
            
        }
        public void Save()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
