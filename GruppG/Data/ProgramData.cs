using GruppG.Models;
using GruppG.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppG.Data
{
    public class ProgramData
    {
        //Class for our methods

        private U4Entities db = new U4Entities();
        private Person pr = new Person();
        Models.db.Program program = new Models.db.Program();
        //private DateTime selectedDates = new DateTime();
        


        public bool CheckUserCreadentials(string username, string password)
        {
            var user = db.Person.Where(p => p.UserName == username && p.Password == password).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public List<Models.db.Program> PuffPrograms()
        {
            var puff = db.Program.Where(p => p.Puff == 1);
            return puff.ToList();
        }

       

        

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
        

        //Metod för att kontrollera vilket datum som valts
        public int testDatum(string inp)
        {
            
            U4Entities pwdb = new U4Entities();
            DateTime date1 = DateTime.Today;
            //DateTime date2 = Convert.ToDateTime();
            var dateresult = db.Program.Where(q => q.Starttime == date1);

            if (inp == "2017-11-12")
            {
                return 1;
            }
            else if (inp == "2017-11-12")
            {
                return 2;
            }
            else if (inp == "2017-11-13")
            {
                return 3;
            }
            else if (inp == "2017-11-13")
            {
                return 4;
            }
            else if (inp == "2017-11-14")
            {
                return 5;
            }
            else if (inp == "2017-11-15")
            {
                return 6;
            }
            else if (inp == "2017-11 -15")
            {
                return 7;
            }
            else
            {
                return 0;
            }
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