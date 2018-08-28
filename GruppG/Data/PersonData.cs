﻿using GruppG.Models.db;
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

        //Hämtar personen med rollen
        public Person GetPersonByRole(int role)
        {
            var person = db.Person.FirstOrDefault(x => x.Role == role);

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

        //Check if user and password exists (Login)
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

        public bool CheckIsUserAdmin ()
        {
            var user = db.Person.Where(p => p.Role == 1);

            if (user.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Check user role
        public bool UserInRole(string userName, int role)
        {
            
            var roles = db.Person.Where(x => x.UserName.Equals(userName));
            //&& x.Role.Equals(role));
            return roles.Any();
        }

        //Check Admin/User
        public string GetRole(int? role)
        {
            var roles = db.Person.Where(x => x.Role == role);
            if (role == 1)
            {
                return "Admin";
            }
            else
                return "Medlem";
            
        }

        public bool CheckUserNameExists(string username)
        {
            var user = db.Person.Any(x => x.UserName == username);

            return true;

        }



    }
}