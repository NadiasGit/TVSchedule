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
    }
}