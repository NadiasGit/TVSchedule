using System;
using GruppG.Models.db;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using GruppG.Data;

namespace GruppG.Models.ViewModels
{
    public class ProgramChannelVM
    {
        public List<Chanel> ChannelListVM { get; set; }
        public List<Program> ProgramListVM { get; set; }
        public List<Category> CategoryListVM { get; set; }
        public List<Program> GetPuffListVM { get; set; }

        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MM-dd}")]
        public List<DateTime> Dates { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MM-dd}")]
        public DateTime Today { get; set; }
 
        public Person Person { get; set; }
        public List<FavoriteChannel> FavoriteChannelsVM { get; set; }

        public ProgramChannelVM()
        {
            /*..:::DATES FOR DROPDOWNLIST:::..*/

            //Om vi/du vill ha aktuella datum:
            //Today = DateTime.Today;

            //Om vi vill se hårdkodade programmen:
            Today = new DateTime(2017, 11, 09);

            Dates = new List<DateTime>();
            Dates.Add(Today);
            Dates.Add(Today.AddDays(1));
            Dates.Add(Today.AddDays(2));
            Dates.Add(Today.AddDays(3));
            Dates.Add(Today.AddDays(4));
            Dates.Add(Today.AddDays(5));
            Dates.Add(Today.AddDays(6));

            Today.ToShortDateString();     

        }





    }
}