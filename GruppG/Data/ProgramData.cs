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

        public bool CheckUserCreadentials(string username, string password)
        {
            var user = db.Person.Where(p => p.UserName == username && p.Password == password).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            return true;
        }


        //Program program = new Program();
        List<U4Entities> ProgramList = new List<U4Entities>();
        List<U4Entities> Svt1List = new List<U4Entities>();
        //List<Program> Svt2List = new List<Program>();
        //List<Program> Tv3List = new List<Program>();
        //List<Program> Tv4List = new List<Program>();
        //List<Program> Kanal5List = new List<Program>();

        //Framtida metoder

        //public List<U4Entities> GetPrograms()
        //{
        //    //Forechloop.Alla program i databasen => lägg till i programlista/ kanallista + per dag lista
        //    //foreach (var item in db.Program)
        //    //{
        //    //    ProgramList.Add(item);
        //    //}

        //    Svt1List = ProgramList.FindAll(s => s.Chanel = 1);

        //}

        //public List<Program> PopluarProgram()
        //{
        //    Visa populära program i egen lista?
        //    Booleansk metod. true = rekomenderad. False = ej i rekomendeade listan ??

        //}


        //public List<Program> Svt1L()
        //{

        //    Svt1List = ProgramList.FindAll(s => s.Channel == 1);
        //    return Svt1List;
        //}

        //public List<Program> Svt1()
        //{
        //    Svt1List = Svt1List.OrderBy(s => s.Time);
        //    return Svt1List;
        //}

        //public List<Program> Svt2L()
        //{
        //    Svt2List = ProgramList.FindAll(s => s.Channel == 1);
        //    return Svt2List;
        //}
        //public List<Program> Tv3L()
        //{
        //    Tv3List = ProgramList.FindAll(s => s.Channel == 1);
        //    return Tv3List;
        //}
        //public List<Program> Tv4L()
        //{
        //    Tv4List = ProgramList.FindAll(s => s.Channel == 1);
        //    return Tv4List;
        //}

        //public List<Program> Kanal5()
        //{
        //    Kanal5List = ProgramList.FindAll(s => s.Channel == 1);
        //    return Kanal5List;
        //}

        //Metoder som kanske kommer ligga i andra klasser

        //Logga in (administratör och besökare)

        //Redigera populära program (lägga till/ta bort) - https://stackoverflow.com/questions/853526/using-linq-to-remove-elements-from-a-listt

        //Besökare ska kunna välja favoritkanaler

        //Hemsidan ska vara responsiv

        //url likt: tv/svt/svtplay




        //Metoder från cirkus-kursen

        //        Sql sqlData = new Sql();
        //            if(sqlData.GetData(query) != null)
        //            {
        //                foreach (DataRow item in sqlData.GetData(query).Rows)
        //                {
        //                    if(item != null)
        //                    {
        //                        Shows NewShow = new Shows()
        //                        {
        //                            ShowId = int.Parse(item["ShowID"].ToString()),
        //                            Name = item["Name"].ToString(),
        //                            Description = item["Description"].ToString(),
        //                            SalesStart = DateTime.Parse(item["SalesStart"].ToString()),
        //                            Date = DateTime.Parse(item["Date"].ToString())
        //                        };
        //        ShowList.Add(NewShow.ShowId, NewShow);
        //                    }
        //}
        //            }



        //Metoder från databaskursen:



        //   //HÄMTA MEDLEMMAR TILL LISTA
        //public List<Member> GetMembers(List<Member> members)
        //{
        //    try
        //    {
        //        conn.Open();
        //        cmd = new NpgsqlCommand("SELECT memberid, firstname, lastname, dateofbirth, address, zipcode, city, email, phonenumber, mobilenumber, gender, photograph FROM member ORDER BY firstname ASC", conn);
        //        dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            members.Add(new Member(dr.GetInt32(dr.GetOrdinal("memberid")), dr["firstname"].ToString(), dr["lastname"].ToString(), dr.GetDateTime(dr.GetOrdinal("dateofbirth")), dr["address"].ToString(), dr.GetInt32(dr.GetOrdinal("zipcode")), dr["city"].ToString(), dr["email"].ToString(), dr["phonenumber"].ToString(), dr["mobilenumber"].ToString(), dr["gender"].ToString(), dr["photograph"].ToString()));
        //        }
        //        return members;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }


        ////LÄGG TILL MEDLEM I DATABASEN
        //public Member AddMember(string firstname, string lastname, DateTime dateofbirth, string address, int zipcode, string city, string email, string phonenumber, string mobilenumber, string gender, string photograph)
        //{
        //    conn.Open();

        //    cmd = new NpgsqlCommand("INSERT INTO member (firstname, lastname, dateofbirth, address, zipcode, city, email, phonenumber, mobilenumber, gender, photograph) VALUES (@fname, @lname, @dateofbirth, @address, @zip, @city, @email, @phone, @mobile, @gender, @photo) RETURNING memberid;", conn);

        //    cmd.Parameters.AddWithValue("@fname", firstname);
        //    cmd.Parameters.AddWithValue("@lname", lastname);
        //    cmd.Parameters.AddWithValue("@dateofbirth", dateofbirth);
        //    cmd.Parameters.AddWithValue("@address", address);
        //    cmd.Parameters.AddWithValue("@zip", zipcode);
        //    cmd.Parameters.AddWithValue("@city", city);
        //    cmd.Parameters.AddWithValue("@email", email);
        //    cmd.Parameters.AddWithValue("@phone", phonenumber);
        //    cmd.Parameters.AddWithValue("@mobile", mobilenumber);
        //    cmd.Parameters.AddWithValue("@gender", gender);
        //    cmd.Parameters.AddWithValue("@photo", photograph);

        //    int memberid = (int)cmd.ExecuteScalar();

        //    conn.Close();

        //    return new Member(memberid, firstname, lastname, dateofbirth, address, zipcode, city, email, phonenumber, mobilenumber, gender, photograph);


        ////UPPDATERA MEDLEM I DATABASEN
        //public Member UpdateMember(int id, string firstname, string lastname, DateTime dateofbirth, string address, int zipcode, string city, string email, string phonenumber, string mobilenumber, string gender, string photograph)
        //{
        //    conn.Open();

        //    cmd = new NpgsqlCommand("UPDATE member SET (firstname, lastname, dateofbirth, address, zipcode, city, email, phonenumber, mobilenumber, gender, photograph) = (@fname, @lname, @dateofbirth, @address, @zip, @city, @email, @phone, @mobile, @gender, @photo) WHERE @id = memberid", conn);

        //    cmd.Parameters.AddWithValue("@id", id);
        //    cmd.Parameters.AddWithValue("@fname", firstname);
        //    cmd.Parameters.AddWithValue("@lname", lastname);
        //    cmd.Parameters.AddWithValue("@dateofbirth", dateofbirth);
        //    cmd.Parameters.AddWithValue("@address", address);
        //    cmd.Parameters.AddWithValue("@zip", zipcode);
        //    cmd.Parameters.AddWithValue("@city", city);
        //    cmd.Parameters.AddWithValue("@email", email);
        //    cmd.Parameters.AddWithValue("@phone", phonenumber);
        //    cmd.Parameters.AddWithValue("@mobile", mobilenumber);
        //    cmd.Parameters.AddWithValue("@gender", gender);
        //    cmd.Parameters.AddWithValue("@photo", photograph);

        //    cmd.ExecuteNonQuery();

        //    conn.Close();

        //    return new Member(id, firstname, lastname, dateofbirth, address, zipcode, city, email, phonenumber, mobilenumber, gender, photograph);
        //}
        ////TA BORT MEDLEM I DATABASEN
        //public void DeleteMember(int id)
        //{
        //    conn.Open();

        //    cmd = new NpgsqlCommand("DELETE FROM member WHERE @id = memberid", conn);

        //    cmd.Parameters.AddWithValue("@id", id);

        //    cmd.ExecuteNonQuery();

        //    conn.Close();

        //}

    }
}