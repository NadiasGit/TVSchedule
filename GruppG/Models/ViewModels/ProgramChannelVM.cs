using System;
using GruppG.Models.db;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace GruppG.Models.ViewModels
{
    public class ProgramChannelVM
    {
        private U4Entities db = new U4Entities();

        //public List<db.Program> Program { get; set; }
        
        //public IEnumerable<Chanel> Channels { get; set; }
        public List<Chanel> ChannelListVM { get; set; }
        public List<Program> ProgramListVM { get; set; }

        public IEnumerable<Program> Programs { get; set; }
        public Program Program { get; set; }
        public List<string> Dates { get; set; }
        public DateTime Today { get; set; }

        public ProgramChannelVM()
        {
            //Om vi/du vill ha aktuella datum
            //DateTime today = DateTime.Now;
            //Om vi vill se hårdkodade programmen
            DateTime today = Convert.ToDateTime("2017-11-09");
            Today = Convert.ToDateTime("2017-11-09");

            Dates = new List<string>();
            Dates.Add(Today.ToShortDateString());
            Dates.Add(Today.AddDays(1).ToShortDateString());
            Dates.Add(Today.AddDays(2).ToShortDateString());
            Dates.Add(Today.AddDays(3).ToShortDateString());
            Dates.Add(Today.AddDays(4).ToShortDateString());
            Dates.Add(Today.AddDays(5).ToShortDateString());
            Dates.Add(Today.AddDays(6).ToShortDateString());


            //Dates.Add(Today.ToShortDateString());
            //Dates.Add(Today.AddDays(1).ToShortDateString());
            //Dates.Add(Today.AddDays(2).ToShortDateString());
            //Dates.Add(Today.AddDays(3).ToShortDateString());
            //Dates.Add(Today.AddDays(4).ToShortDateString());
            //Dates.Add(Today.AddDays(5).ToShortDateString());
            //Dates.Add(Today.AddDays(6).ToShortDateString());

        }


        public List<Program> GetPrograms()
        {
            U4Entities u4 = new U4Entities();

            var result = u4.Program;
            return result.ToList();
        }


        public List<Models.db.Program> GetDate(DateTime date)
        {
            U4Entities u4 = new U4Entities();
            //var result = u4.Program.Where(c => c.Chanel == channel);
            var result = u4.Program.Where(q => q.Programstart == date);
            return result.ToList();
        }
        public List<Chanel> GetChannels()
        {
            U4Entities u4 = new U4Entities();

            var result = u4.Chanel;
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