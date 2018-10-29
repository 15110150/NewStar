using NewStar.Data.Insfrastructure;
using NewStar.Data.Repositories;
using NewStar.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewStar.Service
{
    public interface IStudentService
    {
        Student Add(Student Student);

        void Update(Student Student);

        Student Delete(int id);

        Student GetStudentByID(int id);

        IEnumerable<Student> GetLastest(int top);

        IEnumerable<Student> GetAll();

        IEnumerable<Student> GetAll(string keyword);

        IEnumerable<Student> GetListStudentPaging(int page, int pageSize, string sort, out int totalRow);

        IEnumerable<Student> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        IEnumerable<string> GetListStudentByName(string name);

        void Save();

        IEnumerable<Student> NummberOfStudentIsPotential();
    }

    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository;

        private IUnitOfWork _unitOfWork;

        public StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            this._studentRepository = studentRepository;
            this._unitOfWork = unitOfWork;
        }

        public Student Add(Student Student)
        {
            return _studentRepository.Add(Student);
        }

        public Student Delete(int id)
        {
            return _studentRepository.Delete(id);
        }

        public Student GetStudentByID(int id)
        {
            return _studentRepository.GetSingleByCondition(x => x.ID == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public IEnumerable<Student> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _studentRepository.GetMulti(x => x.Name.Contains(keyword));
            else
                return _studentRepository.GetAll();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Student Student)
        {
            _studentRepository.Update(Student);
        }

        public IEnumerable<Student> GetLastest(int top)
        {
            return _studentRepository.GetMulti(x => x.Status).OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<Student> GetListStudentPaging(int page, int pageSize, string sort, out int totalRow)
        {
            var query = _studentRepository.GetMulti(x => x.Status);

            switch (sort)
            {
                case "potential":
                    query = query.OrderByDescending(x => x.IsPotentialStudent);
                    break;
                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<string> GetListStudentByName(string name)
        {
            return _studentRepository.GetMulti(x => x.Status && x.Name.Contains(name)).Select(y => y.Name);
        }

        public IEnumerable<Student> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _studentRepository.GetMulti(x => x.Status && x.Name.Contains(keyword));

            switch (sort)
            {
                case "potential":
                    query = query.OrderByDescending(x => x.IsPotentialStudent);
                    break;
                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Student> NummberOfStudentIsPotential()
        {
            return _studentRepository.GetMulti(x => x.Status && x.IsPotentialStudent);
        }
    }
}
