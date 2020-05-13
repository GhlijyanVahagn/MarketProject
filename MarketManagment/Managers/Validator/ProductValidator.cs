using DbModel.Products;
using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Managers.Validator
{
    public class ProductValidator:ValidatorBase<ProductViewModel>
    {
  
        public ProductValidator(IEnumerable<ProductViewModel> products, ProductViewModel viewModel):base(products, viewModel)
        {
   
        }

        public override string Validate()
        {
            if (!IsModelValid)
                return ValidationErrorMessage;

            string result;


            if (ViewList == null || ViewItem == null)
                return "sourceIsNull";
            result = isNameDublicated();
            if (result !=string.Empty)
                return result;

            result = isCodeDublicated();
            if (result != string.Empty)
                return result;

            result = isBarCodeDublicated();
            if (result != string.Empty)
                return result;
            result = isUnitMissing();
            if (result != string.Empty)
                return result;

            result = isGroupMissing();
            if (result != string.Empty)
                return result;

            return result;
        }

        private string isNameDublicated()
        {
            var name = ViewItem.Name.Trim().ToLower();
            if (ViewList.FirstOrDefault(x => x.Name.Trim().ToLower() == name) != null)
              //  return (int)EProductCreationValidationTypes.nameIsDublicated;
            return "nameIsDublicated";

            return string.Empty;

        }

        private string isCodeDublicated()
        {
            var unicCode = ViewItem.UnicCode.Trim().ToLower();
            if (ViewList.FirstOrDefault(x => x.UnicCode.Trim().ToLower() == unicCode) != null)
                //return (int)EProductCreationValidationTypes.codeIsDublicated;
            return "codeIsDublicated";

            return string.Empty;

        }

        private string isBarCodeDublicated()
        {
            var unicCode = ViewItem.BarCode.Trim().ToLower();
            if (ViewList.FirstOrDefault(x => x.BarCode.Trim().ToLower() == unicCode) != null)
                //return (int)EProductCreationValidationTypes.barCodeIsDublicated;
                return "barCodeIsDublicated";

            return string.Empty;
        }
        private string isUnitMissing()
        {
            var unitId = ViewItem.UnitId;
            if (unitId <= 0)
                //return (int)EProductCreationValidationTypes.unitIsMissing;
                return "unitIsMissing";

            return string.Empty;

        }

        private string isGroupMissing()
        {
            var groupId = ViewItem.GroupId;
            if (groupId <= 0)
                // return (int)EProductCreationValidationTypes.groupIsMissing;
                return "groupIsMissing";
            return string.Empty;

        }
    }
}
