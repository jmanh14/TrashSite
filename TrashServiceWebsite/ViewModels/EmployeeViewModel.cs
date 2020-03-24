using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashServiceWebsite.Models;

namespace TrashServiceWebsite.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set;  }
        public List<Customer> Customers { get; set; }
        public List<SelectListItem> DayToPickUp { get; set; }
        public DayOfWeek SelectedDay { get; set; }
    }
}
