using DbModel.Products;
using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Managers.Validator
{
    public class ProductValidator:IValidator
    {
        IEnumerable<ProductViewModel> productsList;
        ProductViewModel productView;
        public ProductValidator(IEnumerable<ProductViewModel> products, ProductViewModel viewModel)
        {
            this.productsList = products;
            this.productView = viewModel;
        }

        public int Validate()
        {
            int result = -1;

            if (productsList == null || productView == null)
                return (int)EProductCreationValidationTypes.sourceIsNull;
            result =isNameDublicated();
            if (result != -1)
                return result;

            result=isCodeDublicated();
            if (result != -1)
                return result;

            result=isBarCodeDublicated();
            if (result != -1)
                return result;
           result= isUnitMissing();
            if (result != -1)
                return result;

            result=isGroupMissing();
            if (result != -1)
                return result;

            return result;
        }

        private int isNameDublicated()
        {
            var name = productView.Name.Trim().ToLower();
            if (productsList.FirstOrDefault(x => x.Name.Trim().ToLower() == name) != null)
                return (int)EProductCreationValidationTypes.nameIsDublicated;
            return -1;

        }

        private int isCodeDublicated()
        {
            var unicCode = productView.UnicCode.Trim().ToLower();
            if (productsList.FirstOrDefault(x => x.UnicCode.Trim().ToLower() == unicCode) != null)
                return (int)EProductCreationValidationTypes.codeIsDublicated;
            return -1;

        }

        private int isBarCodeDublicated()
        {
            var unicCode = productView.BarCode.Trim().ToLower();
            if (productsList.FirstOrDefault(x => x.BarCode.Trim().ToLower() == unicCode) != null)
                return (int)EProductCreationValidationTypes.barCodeIsDublicated;
            return -1;
        }
        private int isUnitMissing()
        {
            var unitId = productView.UnitId;
            if (unitId <= 0)
                return (int)EProductCreationValidationTypes.unitIsMissing;
            return -1;

        }

        private int isGroupMissing()
        {
            var groupId = productView.GroupId;
            if (groupId <= 0)
                return (int)EProductCreationValidationTypes.groupIsMissing;
            return -1;

        }
    }
}
