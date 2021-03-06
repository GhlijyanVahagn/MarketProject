﻿using DbManager.Repository;
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

    public class ProducerManager : BaseManager<Producer, ProducerViewModel>
    {
        
        
        public ProducerManager():base(new ProductProducerRepository())
        {
            
        }
        public override void Delete(int Id)
        {
            Repository.Delete(Id);
        }

      

        public override ProducerViewModel Read(int Id)
        {
            return null;
            //return Repository.Read(Id);
        }

        public override void Save()
        {
            Repository.Save();
        }

        public override void Update(ProducerViewModel producer)
        {
            

            //Repository.Update(producer);
        }

     

        public override IEnumerable<ProducerViewModel> ViewModelList()
        {
            return Repository.ViewModelList();
        }
    }

  
    
}
