using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.ViewModel
{
    public class ProductViewModel: ViewBase
    {
       public int GroupId { get; set; }
       public int ProducerId { get; set; }
        public int UnitId { get; set; }
        public string UnicCode { get; set; }
        public string BarCode { get; set; }
        public  ProducerViewModel producerView{ get; set; }
        public  ProductGroupViewModel groupView { get; set; }
        public  ProductUnitViewModel unitView { get; set; }


    }
}
