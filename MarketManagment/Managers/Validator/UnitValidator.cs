using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Managers.Validator
{
    public class UnitValidator : ValidatorBase<ProductUnitViewModel>
    {

        public UnitValidator(IEnumerable<ProductUnitViewModel> ViewList, ProductUnitViewModel viewModel):base( ViewList,viewModel)
        {

        }
        public override string Validate()
        {
            if (!IsModelValid)
                return ValidationErrorMessage;



            if (ViewList == null || ViewItem == null)
                return "sourceIsNull";
           var result = isNameDublicated();
            if (result != string.Empty)
                return "isNameDublicated";

            return string.Empty;
        }

       

        private string isNameDublicated()
        {
            var name = ViewItem.Name.Trim().ToLower();
            if (ViewList.FirstOrDefault(x => x.Name.Trim().ToLower() == name) != null)
                return "nameIsDublicated";

            return string.Empty;

        }
    }
}
