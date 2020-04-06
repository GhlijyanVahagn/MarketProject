using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Managers.Validator
{
    public class UnitValidator : IValidator
    {
        IEnumerable<ProductUnitViewModel> list;
        ProductUnitViewModel item;
        public UnitValidator(IEnumerable<ProductUnitViewModel> source, ProductUnitViewModel item)
        {
            this.list = source;
            this.item = item;
        }
        public int Validate()
        {
            int result = -1;

            if (list == null || item == null)
                return (int)EProductCreationValidationTypes.sourceIsNull;
            result = isNameDublicated();
            if (result != -1)
                return result;

            return result;
        }
        private int isNameDublicated()
        {
            var name = item.Name.Trim().ToLower();
            if (list.FirstOrDefault(x => x.Name.Trim().ToLower() == name) != null)
                return (int)EProductCreationValidationTypes.nameIsDublicated;
            return -1;

        }
    }
}
