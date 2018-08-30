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
        private U4Entities db = new U4Entities();

        //public List<db.Program> Program { get; set; }
        
        //public IEnumerable<Chanel> Channels { get; set; }
        public List<Chanel> ChannelListVM { get; set; }
        public List<Program> ProgramListVM { get; set; }
        public List<Program> ProgramCategoryVM { get; set; }
        public List<Category> CategoryListVM { get; set; }
        //public ListOfDaysModel AllDates { get; set; }
        //public SelectedDate SelectedDate { get; set; }
        public IEnumerable<Program> Programs { get; set; }
        public Program Program { get; set; }
        public List<Program> GetPuffListVM { get; set; }

        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MM-dd}")]
        public List<DateTime> Dates { get; set; }
        public List<string> DateString { get; set; }
        public string date { get; set; }

        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MM-dd}")]
        public DateTime Today { get; set; }
        public List<string> PuffName { get; set; }
        public ProgramData ProgramData { get; set; }


        public ProgramChannelVM()
        {
            //Om vi/du vill ha aktuella datum
            //Today = DateTime.Today;
            //Om vi vill se hårdkodade programmen
            //DateTime today = Convert.ToDateTime("2017-11-09");
            //Today = Convert.ToDateTime("2017-11-09").Date;
            Today = new DateTime(2017, 11, 09);

            Dates = new List<DateTime>();
            Dates.Add(Today);
            Dates.Add(Today.AddDays(1));
            Dates.Add(Today.AddDays(2));
            Dates.Add(Today.AddDays(3));
            Dates.Add(Today.AddDays(4));
            Dates.Add(Today.AddDays(5));
            Dates.Add(Today.AddDays(6));

            DateString = new List<string>();
            DateString.Add(Today.ToShortDateString());
            DateString.Add(Today.AddDays(1).ToShortDateString());
            DateString.Add(Today.AddDays(2).ToShortDateString());
            DateString.Add(Today.AddDays(3).ToShortDateString());
            DateString.Add(Today.AddDays(4).ToShortDateString());
            DateString.Add(Today.AddDays(5).ToShortDateString());
            DateString.Add(Today.AddDays(6).ToShortDateString());

            //Today.ToShortDateString();

            //Försök till att bara visa datum i drop-down-list
            /*
            Today.ToString("dd/mm/yy");       
            Today = DateTime.Parse("2017, 11, 09");
            Today = Today.Date;
            */
            date = "2017, 11, 09";
            var parseddate = DateTime.Parse(date);

            DateString = new List<string>();
            DateString.Add(date);
            DateString.Add("2017, 11, 10");
            DateString.Add("2017, 11, 11");
            DateString.Add("2017, 11, 12");
            DateString.Add("2017, 11, 13");
            DateString.Add("2017, 11, 14");
            DateString.Add("2017, 11, 15");

        }




    }
}