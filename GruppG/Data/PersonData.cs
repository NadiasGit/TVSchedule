using GruppG.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppG.Data
{
    public class PersonData
    {
        private U4Entities db = new U4Entities();
        //Koppla ihop inloggad person med person i databasen.
        public Person GetPersonById(int id)
        {
            var person = db.Person.FirstOrDefault(x => x.Id == id);
            return person;
        }

        public Person RegisterNewPerson(Person pers)
        {
            using (U4Entities newPerson = new U4Entities())
            {
                newPerson.Person.Add(pers);
                newPerson.SaveChanges();
            }
            return pers;
        }

        public bool CheckUser (string username, string password)
        {
                var user = db.Person.Where(p => p.UserName.Equals(username) && p.Password.Equals(password));
                
            if(user.Any())
                {
                return true;    

                }
            else
            {
                return false;

            }

        }


    }
}