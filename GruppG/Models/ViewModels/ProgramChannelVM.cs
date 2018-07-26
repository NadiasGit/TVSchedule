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


        public void GetChannelList()
        {
            foreach (var item in ChannelListVM)
            {

            }
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