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
        
        public IEnumerable<Chanel> Channels { get; set; }
        public IEnumerable<Program> Program { get; set; }
        public Program Programs { get; set; }


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