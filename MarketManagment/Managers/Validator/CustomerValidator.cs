using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Managers.Validator
{
    public class CustomerValidator : ValidatorBase<CustomerViewModel>
    {
        public CustomerValidator(IEnumerable<CustomerViewModel> ViewList, CustomerViewModel ViewItem) : base(ViewList, ViewItem)
        {
        }

        public override string Validate()
        {
            if (!IsModelValid)
                return ValidationErrorMessage;
            return string.Empty;
        }
    }
}
