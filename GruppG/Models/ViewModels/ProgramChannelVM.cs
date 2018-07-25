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

        public IEnumerable<db.Program> Program { get; set; }
        public IEnumerable<db.Chanel> Channel { get; set; }

        //List<string> Channels = new List<string>();
        
   
	
    }
}