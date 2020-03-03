﻿using DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.RepositoryInterfaces
{
    interface IProductProducerRepository:ICrudOperation<Producer>
    {
       
        void Save();
    }
}
