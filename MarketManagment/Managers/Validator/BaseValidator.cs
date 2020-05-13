using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Managers.Validator
{
    public abstract class ValidatorBase<TViewModel>:IValidator
    {
        public IEnumerable<TViewModel> ViewList;
        public TViewModel ViewItem;
        public bool IsModelValid
        {
            get
            {
                return string.IsNullOrEmpty(ValidationErrorMessage);
            }

        }
        public string ValidationErrorMessage { get; }

        public ValidatorBase(IEnumerable<TViewModel> ViewList, TViewModel ViewItem)
        {
            this.ViewList = ViewList;
            this.ViewItem = ViewItem;
            ValidationErrorMessage = ValidateModel(ViewItem);
         
        }
      

        public string ValidateModel(TViewModel model)
        {
            ValidationContext context = new ValidationContext(model);
            IList<ValidationResult> errors = new List<ValidationResult>();
            System.ComponentModel.DataAnnotations.Validator.TryValidateObject(model, context, errors, true);
            if (errors.Count == 0)
                return string.Empty;

            StringBuilder builder = new StringBuilder();
            builder.Append("<div><h3>Validation errors</h3><ul>");
            foreach (var error in errors)
                builder.Append($"<li>{error.ErrorMessage}</li>");
            builder.Append("</ul></div>");

            return builder.ToString();
        }


        public abstract string Validate();
      
    }

   

}
