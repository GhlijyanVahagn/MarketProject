using DbManager.ProductGroupRepository;
using DbManager.RepositoryInterfaces;
using DbModel.Products;
using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Managers.Products
{
    public class ProductGroupManager : BaseManager<ProductGroup, ProductGroupViewModel>
    {
      
        public ProductGroupManager():base(new ProductGroupRepository())
        {

        }

     

        public override void Create(ProductGroupViewModel entity)
        {
            var prodGroup=ConvertView_DTO(entity);
            Repository.Create(prodGroup);

        }

        public override void Delete(int Id)
        {
            Repository.Delete(Id);
        }

        public override async Task<IEnumerable<ProductGroupViewModel>> GetAllAsync()
        {
            // return await Repository.GetAllAsync();
            return null;
        }

        public override ProductGroupViewModel Read(int Id)
        {
            //return Repository.Read(Id);
            return null;
        }

        public override void Save()
        {
            Repository.Save();
        }

     

        public override void Update(ProductGroupViewModel entity)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ProductGroupViewModel> ViewModelList()
        {
            return Repository.ViewModelList();
        }
    }
}
