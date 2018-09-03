using GruppG.Models;
using GruppG.Models.db;
using GruppG.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace GruppG.Data
{
    public class ProgramData
    {
        //Class for our methods

        private U4Entities db = new U4Entities();
        Person pr = new Person();

        Program program = new Program();
        Chanel channel = new Chanel();
        FavoriteChannel favoriteChannel = new FavoriteChannel();
        ProgramChannelVM pcViewModel = new ProgramChannelVM();
        System.Runtime.Caching.ObjectCache cache = MemoryCache.Default;
        PersonData personData = new PersonData();
        

        //Get programs
        public List<Program> GetPrograms()
        {
            var result = db.Program;
            return result.ToList();
        }
   

        public Program GetSpecificProgram(int id)
        {
            var prog = db.Program.Single(e => e.Id == id);
            return (prog);
        }

        //Get channels
        public List<Chanel> GetChannels()
        {
            var result = db.Chanel;
            return result.ToList();
        }

        //Get categories
        public List<Category> GetCategories()
        {
            var result = db.Category;
            return result.ToList();
        }

        //Get person by id
        public Person GetPersonById(int id)
        {
            var result = db.Person.First(e => e.Id == id);
            return result;
        }

        public Person GetPersonIdentity(string name)
        {
            var id = personData.GetId(name);
            var iid = db.Person.Single(x => x.Id == id);
            return iid;
        }


        #region PUFF-METHODS
        //Puffar/rekommenderade program
        public List<Program> PuffPrograms()
        {
            var result = db.Program.Where(p => p.Puff == 1).Where(p => p.Programstart >= pcViewModel.Today).ToList();
            return result;
        }
        public bool CountPuff()
        {
            if (PuffPrograms().Count >= 3)
            {
                return true;
            }
            return false;
        }

        public string PuffName(int? puff)
        {
            if (puff == 1)
            {
                return "Ja";
            }
            else
            {
                return "Nej";
            }
        }
        #endregion


        #region FavoriteChannels-Methods

        //Get favoritechannels by person-id
        public List<FavoriteChannel> GetFavoriteChannels(int person)
        {
            var favChannel = db.FavoriteChannel.Where(f => f.Person == person).OrderBy(c => c.Chanel).ToList();
            return favChannel;
        }

        public List<FavoriteChannel> GetFavoriteChannels(int person, int channel)
        {
            var favCannel = db.FavoriteChannel.Where(f => f.Person == person).Where(f => f.Chanel == channel).OrderBy(c => c.Chanel).ToList();
            return favCannel;
        }

        //Checks if channel allready exists in favoritechannel
        public bool CheckFavChanExists(int? pers, int? chan)
        {
            if (db.FavoriteChannel.Where(p => p.Person == pers && p.Chanel == chan).Any())
            {
                return true;
            }
            else
                return false;
        }
        #endregion


        #region Filter-Methods
        //Filter-methods
        public ProgramChannelVM FilterProgramsByDateAndCategory(DateTime? date, int? id = null)
        {
            
            var channel = GetChannels();
            var program = GetPrograms();

            var progCategories = GetPrograms();
            var cat = GetCategories();

            if (date == null && id == null)
            {
                var programStart = program.Where(d => d.Programstart.Value.ToShortDateString() == pcViewModel.Today.ToShortDateString()).OrderBy(d => d.Programstart).ToList();
                pcViewModel.ProgramListVM = programStart;
            }
            else if (date != null &&  id == null)
            {
                var programDate = program.Where(d => d.Programstart.Value.ToShortDateString() == date.Value.ToShortDateString()).OrderBy(d => d.Programstart).ToList();
                pcViewModel.ProgramListVM = programDate;
            }
            else if (date == null && id != null)
            {
                var programDateCat = program.Where(d => d.Programstart.Value.ToShortDateString() == pcViewModel.Today.ToShortDateString()).OrderBy(d => d.Programstart).Where(c => c.Category == id).ToList();
                pcViewModel.ProgramListVM = programDateCat;
            }
            else
            {
                var catDate = program.Where(d => d.Programstart.Value.ToShortDateString() == date.Value.ToShortDateString()).OrderBy(d => d.Programstart).Where(c => c.Category == id).ToList();
               
                pcViewModel.ProgramListVM = catDate;
            }

            pcViewModel.ChannelListVM = channel;
            pcViewModel.CategoryListVM = cat;
            
            return pcViewModel;
        }



        public ProgramChannelVM FilterProgramsByDateAndCategoryMyPage(string name, DateTime? date, int? category = null)
        {
            var id = personData.GetId(name);
            var iid = db.Person.Single(x => x.Id == id);
            var channel = GetChannels();
            var program = GetPrograms();
            var fav = GetFavoriteChannels(id);
            var cat = GetCategories();
            var favoriteChannel = GetFavoriteChannels(id);

            if (date == null && category == null)
            {
                var programStart = program.Where(d => d.Programstart.Value.ToShortDateString() == pcViewModel.Today.ToShortDateString()).OrderBy(d => d.Programstart).ToList();
                pcViewModel.ProgramListVM = programStart;

            }
            else if (date != null && category == null)
            {
                var programDate = program.Where(d => d.Programstart.Value.ToShortDateString() == date.Value.ToShortDateString()).OrderBy(d => d.Programstart).ToList();
                pcViewModel.ProgramListVM = programDate;
            }
            else if (date == null && category != null)
            {
                var programDateCat = program.Where(d => d.Programstart.Value.ToShortDateString() == pcViewModel.Today.ToShortDateString()).OrderBy(d => d.Programstart).Where(c => c.Category == category).ToList();
                pcViewModel.ProgramListVM = programDateCat;
            }
            else
            {
                var catDate = program.Where(d => d.Programstart.Value.ToShortDateString() == date.Value.ToShortDateString()).OrderBy(d => d.Programstart).Where(c => c.Category == category).ToList();

                pcViewModel.ProgramListVM = catDate;
            }

            
            pcViewModel.FavoriteChannelsVM = favoriteChannel;
            pcViewModel.Person = iid;
            pcViewModel.ChannelListVM = channel;
            pcViewModel.CategoryListVM = cat;

            return pcViewModel;
        }
        public ProgramChannelVM FilterProgramsByDateAndChannel(DateTime? date, int? id = null)
        {
            
            var channel = GetChannels();
            var program = GetPrograms();
            var puff = PuffPrograms();

            if (date == null && id == null)
            {
                var programStart = program.Where(d => d.Programstart.Value.ToShortDateString() == pcViewModel.Today.ToShortDateString()).ToList();
                pcViewModel.ProgramListVM = programStart;
            }
            else if (date != null && id == null)
            {
                var programDate = program.Where(d => d.Programstart.Value.ToShortDateString() == date.Value.ToShortDateString()).OrderBy(d => d.Programstart).ToList();

                pcViewModel.ProgramListVM = programDate;
            }
            else if (date == null && id != null)
            {
                var programCat = program.Where(d => d.Programstart.Value.ToShortDateString() == pcViewModel.Today.ToShortDateString()).OrderBy(d => d.Programstart).Where(c => c.Chanel == id).ToList();

                pcViewModel.ProgramListVM = programCat;
            }
            else
            {
                var channelDateChan = program.Where(d => d.Programstart.Value.ToShortDateString() == date.Value.ToShortDateString()).OrderBy(d => d.Programstart).Where(c => c.Chanel == id).ToList();

                pcViewModel.ProgramListVM = channelDateChan;
            }

            pcViewModel.ChannelListVM = channel;
            pcViewModel.GetPuffListVM = puff;

            return pcViewModel;
        }

        //Filter-methods NY! Med string istället för dateTime
        public ProgramChannelVM FilterProgramsByDAndCategoryMyPage(int id, string date, int? category = null)
        {
            var channel = GetChannels();
            var program = GetPrograms();
            var fav = GetFavoriteChannels(id);
            var cat = GetCategories();

            if (date == null && category == null)
            {
                var programStart = program.Where(d => d.Programstart.Value.ToShortDateString() == pcViewModel.Today.ToShortDateString()).OrderBy(d => d.Programstart).ToList();
                pcViewModel.ProgramListVM = programStart;

            }
            else if (date != null && category == null)
            {
                var programDate = program.Where(d => d.Programstart.Value.ToShortDateString() == date).OrderBy(d => d.Programstart).ToList();
                pcViewModel.ProgramListVM = programDate;
            }
            else if (date == null && category != null)
            {
                var programDateCat = program.Where(d => d.Programstart.Value.ToShortDateString() == pcViewModel.Today.ToShortDateString()).OrderBy(d => d.Programstart).Where(c => c.Category == category).ToList();
                pcViewModel.ProgramListVM = programDateCat;
            }
            else
            {
                var catDate = program.Where(d => d.Programstart.Value.ToShortDateString() == date).OrderBy(d => d.Programstart).Where(c => c.Category == category).ToList();

                pcViewModel.ProgramListVM = catDate;
            }

            pcViewModel.ChannelListVM = channel;
            pcViewModel.CategoryListVM = cat;

            return pcViewModel;
        }





        #endregion


    }

}