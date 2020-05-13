using DbModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage ="Name can't be empty")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        [DataType(DataType.DateTime,ErrorMessage = "Inccorect Date Formar")]
        public DateTime Birthday { get; set; }
        [EmailAddress(ErrorMessage ="Incorrect email address")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Incorrect email address")]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Description  { get; set; }

       
    }
}
