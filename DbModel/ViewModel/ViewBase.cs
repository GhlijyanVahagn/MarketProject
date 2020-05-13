using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.ViewModel
{
    public abstract class ViewBase
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name can't be empty")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
