using DbManager.DatabaseContext;
using DbManager.RepositoryInterfaces;
using DbModel;
using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Repository
{
    public class CustomerRespository : IRepository<Customer, CustomerViewModel>
    {
        public CustomerDbContext context { get; set; }
      
        public CustomerRespository()
        {
            context = new CustomerDbContext();
        }

        //DataBaseManager IRepository<Customer, CustomerViewModel>.context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Create(Customer entity)
        {

            context.Customer.Add(entity);
        }

        public void Delete(int Id)
        {
            var currentCustomer = context.Customer.Find(Id);
            context.Customer.Remove(currentCustomer);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await context.Customer.ToListAsync();
        }

        public Customer Read(int Id)
        {
            return context.Customer.Find(Id);
        }

        public void Save()
        {
             context.SaveChangesAsync();
        }

        public void Update(Customer entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public IEnumerable<CustomerViewModel> ViewModelList()
        {
            List<CustomerViewModel> result = new List<CustomerViewModel>();
            var customers = context.Customer.ToList();
            foreach (var item in customers)
            {
                var view = MarketMapper.Mapper.Map<Customer, CustomerViewModel>(item);
                result.Add(view);

            }
            return result;
        }

    
    }
}
