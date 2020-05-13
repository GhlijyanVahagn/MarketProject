using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbManager;
using DbManager.Repository;
using DbManager.RepositoryInterfaces;
using DbModel.Products;
using DbModel.ViewModel;

namespace MarketManagment.Managers.Products
{
    public class UnitManager : BaseManager<Unit, ProductUnitViewModel>
    {
        public UnitManager():base(new ProductUnitRepository())
        {

        }
        //public override void Create(ProductUnit entity)
        //{
        //    Repository.Create(entity);
        //}

        //public override void Create(ProductUnitViewModel entity)
        //{
        //    var unitModel = ConvertViewModeltoDbModel(entity);
        //    Repository.Create(unitModel);
        //    Save();
        //}

        public override void Delete(int Id)
        {
            Repository.Delete(Id);
        }

      

        public override ProductUnitViewModel Read(int Id)
        {
            //return Repository.Read(Id);
            return null;
        }

        public override void Save()
        {
            Repository.Save();
        }

      

        public override void Update(ProductUnitViewModel entity)
        {
            //Repository.Update(entity);
        }

        public override IEnumerable<ProductUnitViewModel> ViewModelList()
        {
            return Repository.ViewModelList();
        }
    }
}
