using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class JobManager : IGenericService<Job>
    {
        IJobDal jobDal;

        public JobManager(IJobDal jobDal)
        {
            this.jobDal = jobDal;
        }

        public Job GetById(int id)
        {
            return jobDal.GetById(id);
        }

        public void Tdelete(Job t)
        {
            jobDal.Delete(t);
        }

        public List<Job> TGetList()
        {
            return jobDal.GetList();
        }

        public void TInsert(Job t)
        {
            jobDal.Insert(t);
        }

        public void Tupdate(Job t)
        {
            jobDal.Update(t);
        }

        public static implicit operator JobManager(CustomerManager v)
        {
            throw new NotImplementedException();
        }
    }
}
