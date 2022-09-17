using KittenFactory.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenFactory.Core.Entities
{
    public class Cat : Entity
    {
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public DateTime DateOfBirth { get; set; } = DateTime.Today;

    }
}
