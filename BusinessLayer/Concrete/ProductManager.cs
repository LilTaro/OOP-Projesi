using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IGenericService<Product>
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public void Tdelete(Product t)
        {
            _productDal.Delete(t);
        }

        public List<Product> TGetList()
        {
            return _productDal.GetList();
        }

        public void TInsert(Product t)
        {
           _productDal.Insert(t);
        }

        public void Tupdate(Product t)
        {
            _productDal.Update(t);
        }
    }
}
