using DbManager.Repository;
using DbModel.Products;
using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Managers.Products
{
    public class ProductManager:BaseManager<Product,ProductViewModel>
    {
        public ProductManager():base(new ProductRepository())
        {

        }

        //public override void Create(Product entity)
        //{
        //    Repository.Create(entity);
        //}

        //public override void Create(ProductViewModel entity)
        //{
        //    var product = ConvertViewModeltoDbModel(entity);
        //    Repository.Create(product);
        //}

        public override void Delete(int Id)
        {
            Repository.Delete(Id);
    
        }

      

    

        public override ProductViewModel Read(int Id)
        {
            //return Repository.Read(Id);
            return null;

        }

        public override void Save()
        {
            Repository.Save();
        }

        //public override void Update(Product entity)
        //{
        //    Repository.Update(entity);
        //}

        public override void Update(ProductViewModel entity)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ProductViewModel> ViewModelList()
        {
            return Repository.ViewModelList();
        }
    }
}
