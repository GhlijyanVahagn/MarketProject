using DbModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.ViewModel
{
    public class CustomerViewModel:ViewBase
    {
        [Required(ErrorMessage ="Surname can't be empty")]
        public string Surname { get; set; }
        public int GenderId { get; set; }
        [DataType(DataType.Date,ErrorMessage = "Incorrect date fromat")]
        public DateTime Birthday { get; set; }
        [EmailAddress(ErrorMessage ="Incorrect email address")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
