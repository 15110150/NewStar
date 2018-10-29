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
    public interface ICourseService
    {
        Course Add(Course Course);

        void Update(Course Course);

        Course Delete(int id);

        Course GetCourseByID(int id);

        IEnumerable<Course> GetLastest(int top);

        IEnumerable<Course> GetAll();

        IEnumerable<Course> GetAll(string keyword);

        IEnumerable<Course> GetListCoursePaging(int page, int pageSize, string sort, out int totalRow);

        IEnumerable<Course> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        IEnumerable<string> GetListCourseByName(string name);

        void Save();
    }

    public class CourseService : ICourseService
    {
        private ICourseRepository _courseRepository;

        private IUnitOfWork _unitOfWork;

        public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            this._courseRepository = courseRepository;
            this._unitOfWork = unitOfWork;
        }

        public Course Add(Course Course)
        {
            return _courseRepository.Add(Course);
        }

        public Course Delete(int id)
        {
            return _courseRepository.Delete(id);
        }

        public Course GetCourseByID(int id)
        {
            return _courseRepository.GetSingleByCondition(x => x.ID == id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _courseRepository.GetAll();
        }

        public IEnumerable<Course> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _courseRepository.GetMulti(x => x.Name.Contains(keyword));
            else
                return _courseRepository.GetAll();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Course Course)
        {
            _courseRepository.Update(Course);
        }

        public IEnumerable<Course> GetLastest(int top)
        {
            return _courseRepository.GetMulti(x => x.Status).OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<Course> GetListCoursePaging(int page, int pageSize, string sort, out int totalRow)
        {
            var query = _courseRepository.GetMulti(x => x.Status);

            switch (sort)
            {
                case "price":
                    query = query.OrderByDescending(x => x.Prices);
                    break;
                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<string> GetListCourseByName(string name)
        {
            return _courseRepository.GetMulti(x => x.Status && x.Name.Contains(name)).Select(y => y.Name);
        }

        public IEnumerable<Course> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _courseRepository.GetMulti(x => x.Status && x.Name.Contains(keyword));

            switch (sort)
            {
                case "price":
                    query = query.OrderByDescending(x => x.Prices);
                    break;
                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
