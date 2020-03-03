﻿using DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.ProductGroupRepository
{
    public interface IProductGroupRepository:ICrudOperation<ProductGroup>
    {
        
        void Save();
    }
}
