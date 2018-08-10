using GruppG.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppG.Models.ViewModels
{
    public class FavoritChannelVM
    {
        public int Person { get; set; }
        public int Chanel { get; set; }
        public string ChannelName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Person PersonP { get; set; }
        public List<Chanel> ChannelListVM { get; set; }
        public List<Program> ProgramListVM { get; set; }

    }
}