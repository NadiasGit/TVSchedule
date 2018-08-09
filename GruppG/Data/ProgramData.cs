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
        private Person pr = new Person();
        Program program = new Program();
        Chanel channel = new Chanel();
        List<Program> puffList;
        ProgramChannelVM viewModel = new ProgramChannelVM();
        //private DateTime selectedDates = new DateTime();
         System.Runtime.Caching.ObjectCache cache = MemoryCache.Default;

        public ProgramData()
        {
            puffList = cache["puffList"] as List<Program>;
            if (puffList == null)                            //Kolla om det finns en lista
            {
                puffList = new List<Program>();             //Annars lista produkter i products
            }
        }

        //Save --remove?
        public void Commit()
        {
            cache["puffList"] = puffList;
        }

        

        //Get programs
        public List<Program> GetPrograms()
        {
            U4Entities u4 = new U4Entities();

            var result = u4.Program;
            return result.ToList();
        }


        public bool CheckUserCreadentials(string username, string password)
        {
            var user = db.Person.Where(p => p.UserName == username && p.Password == password).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public List<Program> PuffPrograms()
        {
            
            
            
            //.Where(p => p.Programstart >= p.Programstart.Value.AddDays(-1)).ToList()
            puffList = db.Program.Where(p => p.Puff == 1).Where(p => p.Programstart >= viewModel.Today).ToList();

            //var puff = db.Program.Where(p => p.Puff == 1);
            return puffList;
        }

        public bool CountPuff()
        {
            if(PuffPrograms().Count >= 3)
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


        //Ny metod 15 dec. 2017
        //Hämtar kanalen via en parameter, en början till att kunna ta bort alla partialViews :)
        public List<Models.db.Program>GetChannel(int channel, DateTime date)
        {
            U4Entities u4 = new U4Entities();
            //var result = u4.Program.Where(c => c.Chanel == channel);
            var result = u4.Program.Where(Program => Program.Chanel == channel).Where(q => q.Starttime == date);
            return result.ToList();
        }

        
        //public List<Chanel> GetChannels()
        //{
        //    U4Entities u4 = new U4Entities();

        //    var result = u4.Chanel;
        //    return result.ToList();
        //}



        //Metod som hämtar angiven kanal samt kontrollerar dag/datum.
        public List<Models.db.Program> test(int channel, string date)
        {
            U4Entities u4 = new U4Entities();
            var result = u4.Program.Where(Program => Program.Chanel == channel);
            var programs = from s in result
                           select s;
            switch (date)
            {
                case "friday":
                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/10/2017"));
                    break;
                case "saturday":
                    programs = programs.OrderBy(s => s.Starttime == Convert.ToDateTime("11/11/2017"));
                    break;
                case "sunday":
                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/12/2017"));
                    break;
                case "monday":
                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/13/2017"));
                    break;
                case "tuesday":
                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/14/2017"));
                    break;
                case "wednesday":
                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/15/2017"));
                    break;
                case "thursday":
                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/16/2017"));
                    break;
                default:
                    programs = programs.OrderBy(s => s.Starttime == DateTime.Today);
                    break;
            }
            return programs.ToList();
        }

        public List<Models.db.Program> SortByDate(string sortDate)
        {
                      
            var programs = from s in db.Program
                           select s;
            switch (sortDate)
            {
                case "friday":
                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/10/2017"));
                    break;
                case "saturday":
                    programs = programs.OrderBy(s => s.Starttime == Convert.ToDateTime("11/11/2017"));
                    break;
                case "sunday":
                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/12/2017"));
                    break;
                case "monday":
                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/13/2017"));
                    break;
                case "tuesday":
                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/14/2017"));
                    break;
                case "wednesday":
                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/15/2017"));
                    break;
                case "thursday":
                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/16/2017"));
                    break;
                default:
                    programs = programs.OrderBy(s => s.Starttime == DateTime.Today);
                    break;
            }
            return programs.ToList();
        }

        //------------------------------------------------------------------------

        //:::::HÄMTA DATUM-FÖRSÖK::::::::
        public List<Models.db.Program> SVT1(DateTime sortBy)
        {
            U4Entities pwdb = new U4Entities();
            //DateTime date2 = DateTime.Today;
            var p = pwdb.Program.Where(Program => Program.Chanel == 1);
            //var dr = db.Program.Include(q => q.Starttime);

            return p.ToList();
            //return p = p.OrderBy(t => t.Starttime).ToList();
        }

        //public List<Models.db.Program> ProgramsByChannel()
        //{

        //    var p = db.Program.Where(Program => Program.Chanel);
            
        //    return p.ToList();
        //}

        public List<Models.db.Program> SVT2()
        {
            U4Entities pwdb = new U4Entities();
            DateTime date2 = DateTime.Today;
            var p = pwdb.Program.Where(Program => Program.Chanel == 2).Where(q => q.Starttime == date2);
            var dateresult = db.Program.Where(q => q.Starttime == date2);

            return p.ToList();
        }

        public List<Models.db.Program> SVT2Date()
        {
            DateTime date2 = DateTime.Today;
            var dateresult = db.Program.Where(q => q.Starttime == date2);
            //DateTime dateOnly = date1.Date;

            return dateresult.ToList();
        }

        //Call method for if-statement
        static void Main()
        {
            // Call method with embedded if-statement three times.
            DateTime date1 = DateTime.Today;
            
        }
        



        
        List<U4Entities> ProgramList = new List<U4Entities>();
        List<U4Entities> Svt1List = new List<U4Entities>();

      
        
        public List<U4Entities> GetProgramDate()
        {
            //ProgramList = new List<U4Entities>();
            U4Entities pwdb = new U4Entities();
            

            var p = pwdb.Program.Where(Program => Program.Starttime == DateTime.Today);

            //Forechloop.Alla program i databasen => lägg till i programlista/ kanallista + per dag lista
            foreach (var i in ProgramList)
            {
               ProgramList.Add(i);
            }

            return ProgramList.ToList();

        }

    }

}