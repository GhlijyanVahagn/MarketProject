using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Managers.Validator
{
    public class MarketValidator
    {
        IValidator validator;
        public MarketValidator(IValidator validator)
        {
            this.validator = validator;
        }

        public string Validate()
        {
           return  validator.Validate();
        }
    }
}
