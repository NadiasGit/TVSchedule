using GruppG.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GruppG.Data
{
    public class PersonData
    {
        private U4Entities db = new U4Entities();

        public Person GetPersonById(int id)
        {
            var person = db.Person.FirstOrDefault(x => x.Id == id);
            return person;
        }

        public Person GetPersonByUserName(string name)
        {
            var person = db.Person.First(x => x.UserName == name);
            return person;
        }

        public int GetId(string username)
        {
            var usId = db.Person.Where(u => u.UserName == username).Select(usr => new
            {
                Id = usr.Id,
                Name = usr.UserName
            }).FirstOrDefault();

            var pId = usId.Id;

            return pId;
        }

        public int GetId(string username, string password)
        {
             var usId = db.Person.Where(u => u.UserName == username && u.Password == password).Select(usr => new
            {
                Id = usr.Id,
                Name = usr.UserName}).FirstOrDefault();

            var pId = usId.Id;

            return pId;
        }

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

        public bool CheckUserExists(string username)
        {
            if (db.Person.Where(p => p.UserName == username).Any())
            {
                return true;
            }
            else
                return false;
        }

        //Check if user and password exists (Login)
        public bool CheckUser (string username, string password)
        {
                var user = db.Person.Where(p => p.UserName.Equals(username) && p.Password.Equals(password)).Include(i => i.Id);
            if (user.Any())
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
        public bool UserInRole(string userName, string roleType)
        {

            //var role = db.Person.Where(x => x.UserName.Equals(userName) && x.Role.Equals(roleName));

            var role = db.Person.Where(x => x.UserName.Equals(userName)).Include(x => x.Role1).Where(x => x.Role1.Type.Equals(roleType));
            //var r = db.Role.Where(x => x.Type == roleName);
            return role.Any();
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