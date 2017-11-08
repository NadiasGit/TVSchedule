using GruppG.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppG.Data
{
    public class ChannelData
    {

        private U4Entities db = new U4Entities();

        List<Program> ProgramsToDayList = new List<Program>();

        public List<Program> Today()
        {
            var today = DateTime.Today;
            var thisDay = db.Program.Where(x => x.Starttime == today).ToList();
            //where t.date >= new DateTime(2007, 9, 9) && t.date < new DateTime(2008, 1, 1) select t;
            return thisDay;
            
        }



    }
}