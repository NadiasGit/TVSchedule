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
        //public Chanel Channel { get; set; }
        //public FavoriteChannel FavoriteChannel { get; set; }
        //public List<Chanel> ChannelListVM { get; set; }
        //public List<Program> ProgramListVM { get; set; }
        public List<FavoriteChannel> FavoriteChannelsVM { get; set; }

    }
}