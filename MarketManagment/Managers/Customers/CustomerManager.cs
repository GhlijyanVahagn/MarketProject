using DbManager.Repository;
using DbModel;
using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Managers.Customers
{
    public class CustomerManager : BaseManager<Customer, CustomerViewModel>
    {
        public CustomerManager():base(new CustomerRespository())
        {

        }
    

        public override void Delete(int Id)
        {
            throw new NotImplementedException();
        }

     

        public override CustomerViewModel Read(int Id)
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Update(CustomerViewModel entity)
        {

            throw new NotImplementedException();
        }

        public override IEnumerable<CustomerViewModel> ViewModelList()
        {
            throw new NotImplementedException();
        }
    }
}
