using System;
using GruppG.Models.db;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace GruppG.Models.ViewModels
{
    public class ProgramChannelVM : U4Entities
    {
        private U4Entities db = new U4Entities();

        //public List<db.Program> Program { get; set; }
        
        //public IEnumerable<Chanel> Channels { get; set; }
        public Chanel ChannelListVM { get; set; }
        public Program ProgramVM { get; set; }

        public IEnumerable<Program> Programs { get; set; }
        public Program Program { get; set; }
        public List<Chanel> ChannelTest = new List<Chanel>();

        public List<Program> GetPrograms()
        {
            U4Entities u4 = new U4Entities();

            var result = u4.Program;
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