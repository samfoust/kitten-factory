using KittenFactory.Shared.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenFactory.Shared.ViewModels
{
    public class CatViewModel : BaseViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name too long (50 character limit).")]
        public string Name { get; set; }
        
        [StringLength(50, ErrorMessage = "Address too long (50 character limit).")]
        public string Address { get; set; }

        [StringLength(20, ErrorMessage = "Phone too long (20 character limit).")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Image url too long (250 character limit).")]
        public string ImageUrl { get; set; }
       
        public DateTime DateOfBirth { get; set; }
    }
}
