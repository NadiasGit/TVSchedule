using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppG.Data
{
    public class ListOfDaysModel
    {
        public int Id { get; set; }
        public DateTime? Today { get; set; }
        


        public List<ListOfDaysModel>GetDays()
        {
            //Referens: https://stackoverflow.com/questions/30710860/how-to-format-the-datetime-using-html-dropdownlistfor

            //För aktuella datum:
            //DateTime day = DateTime.Today; 

            //För hårdkodade program:
            DateTime day = new DateTime(2017, 11, 09);

            return new List<ListOfDaysModel>()
            {
            new ListOfDaysModel { Id = 1, Today = day },
            new ListOfDaysModel { Id = 1, Today = day.AddDays(1) },
            new ListOfDaysModel { Id = 1, Today = day.AddDays(2) },
            new ListOfDaysModel { Id = 1, Today = day.AddDays(3) },
            new ListOfDaysModel { Id = 1, Today = day.AddDays(4) },
            new ListOfDaysModel { Id = 1, Today = day.AddDays(5) },
            new ListOfDaysModel { Id = 1, Today = day.AddDays(6) }
            };


        }
    }
}