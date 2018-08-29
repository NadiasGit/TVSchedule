using GruppG.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppG.Models.ViewModels
{
    public class FavoritChannelVM : ProgramChannelVM
    {
        

        public Person PersonP { get; set; }
        public Chanel Channel { get; set; }
        public FavoriteChannel FavoriteChannel { get; set; }
        //public List<Chanel> ChannelListVM { get; set; }
        //public List<Program> ProgramListVM { get; set; }
        public List<FavoriteChannel> FavoriteChannelsVM { get; set; }


        public FavoritChannelVM()
        {
            
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