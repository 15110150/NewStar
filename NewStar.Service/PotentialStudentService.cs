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
    public interface IPotentialStudentService
    {
        PotentialStudent Add(PotentialStudent PotentialStudent);

        void Update(PotentialStudent PotentialStudent);

        PotentialStudent Delete(int id);

        PotentialStudent GetPotentialStudentByID(int id);

        IEnumerable<PotentialStudent> GetLastest(int top);

        IEnumerable<PotentialStudent> GetAll();

        IEnumerable<PotentialStudent> GetAll(string keyword);

        IEnumerable<PotentialStudent> GetListPotentialStudentPaging(int page, int pageSize, string sort, out int totalRow);

        IEnumerable<PotentialStudent> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        IEnumerable<string> GetListPotentialStudentByName(string name);

        void Save();
    }

    public class PotentialStudentService : IPotentialStudentService
    {
        private IPotentialStudentRepository _potentialStudentRepository;

        private IUnitOfWork _unitOfWork;

        public PotentialStudentService(IPotentialStudentRepository potentialStudentRepository, IUnitOfWork unitOfWork)
        {
            this._potentialStudentRepository = potentialStudentRepository;
            this._unitOfWork = unitOfWork;
        }

        public PotentialStudent Add(PotentialStudent PotentialStudent)
        {
            return _potentialStudentRepository.Add(PotentialStudent);
        }

        public PotentialStudent Delete(int id)
        {
            return _potentialStudentRepository.Delete(id);
        }

        public PotentialStudent GetPotentialStudentByID(int id)
        {
            return _potentialStudentRepository.GetSingleByCondition(x => x.ID == id);
        }

        public IEnumerable<PotentialStudent> GetAll()
        {
            return _potentialStudentRepository.GetAll();
        }

        public IEnumerable<PotentialStudent> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _potentialStudentRepository.GetMulti(x => x.Name.Contains(keyword));
            else
                return _potentialStudentRepository.GetAll();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(PotentialStudent PotentialStudent)
        {
            _potentialStudentRepository.Update(PotentialStudent);
        }

        public IEnumerable<PotentialStudent> GetLastest(int top)
        {
            return _potentialStudentRepository.GetMulti(x => x.Status).OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<PotentialStudent> GetListPotentialStudentPaging(int page, int pageSize, string sort, out int totalRow)
        {
            var query = _potentialStudentRepository.GetMulti(x => x.Status);
            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<string> GetListPotentialStudentByName(string name)
        {
            return _potentialStudentRepository.GetMulti(x => x.Status && x.Name.Contains(name)).Select(y => y.Name);
        }

        public IEnumerable<PotentialStudent> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _potentialStudentRepository.GetMulti(x => x.Status && x.Name.Contains(keyword));

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
    }
}
