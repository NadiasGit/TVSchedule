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
        public ListOfDaysModel AllDates { get; set; }
        public SelectedDate SelectedDate { get; set; }
        public IEnumerable<Program> Programs { get; set; }
        public Program Program { get; set; }
        public List<Program> GetPuffListVM { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public List<DateTime> Dates { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Today { get; set; }
        public List<string> PuffName { get; set; }
        

        public ProgramChannelVM()
        {
            //Om vi/du vill ha aktuella datum
            //Today = DateTime.Today;
            //Om vi vill se hårdkodade programmen
            //DateTime today = Convert.ToDateTime("2017-11-09");
            //Today = Convert.ToDateTime("2017-11-09").Date;
            Today = new DateTime(2017, 11, 09);

            Dates = new List<DateTime>();
            Dates.Add(Today.Date);
            Dates.Add(Today.AddDays(1));
            Dates.Add(Today.AddDays(2));
            Dates.Add(Today.AddDays(3));
            Dates.Add(Today.AddDays(4));
            Dates.Add(Today.AddDays(5));
            Dates.Add(Today.AddDays(6));

            PuffName = new List<string>() { "Nej", "Ja"};

        }

       

        public List<Program> GetPrograms()
        {
            U4Entities u4 = new U4Entities();

            var result = u4.Program;
            return result.ToList();
        }

        public List<Category> GetCategories()
        {
            U4Entities u4 = new U4Entities();

            var result = u4.Category;
            return result.ToList();
        }

        public List<Program> GetDate(DateTime date)
        {
            U4Entities u4 = new U4Entities();
            var result = u4.Program.Where(q => q.Programstart == date);
            return result.ToList();
        }
        public List<Chanel> GetChannels()
        {
            U4Entities u4 = new U4Entities();

            var result = u4.Chanel;
            return result.ToList();
        }

        public List<Program> GetCategoriesTest(int id)
        {
            U4Entities u4 = new U4Entities();

            var result = u4.Program.Where(c => c.Category == id);
            return result.ToList();
        }

        //List<string> Channels = new List<string>();

        //public List<Program> GetChannelPrograms(string channel)
        //{
        //    U4Entities u4 = new U4Entities();
        //    //var result = u4.Program.Where(c => c.Chanel == channel);
        //    var result = u4.Program.Where(Program => Program.Chanel.ToString() == channel);
        //    return result.ToList();
        //}



    }
}