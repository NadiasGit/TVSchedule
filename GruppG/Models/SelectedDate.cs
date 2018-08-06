using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppG.Models
{
    public class SelectedDate
    {
        public int Id { get; set; }
        public List<SelectListItem> SelectedDates { get; set; }

        public SelectedDate()
        {
            //Behövs en lista verkligen??? (max ett datum åt gången!?)
            SelectedDates = new List<SelectListItem>();
        }
    }
}