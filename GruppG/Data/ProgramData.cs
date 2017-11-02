using GruppG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppG.Data
{
    public class ProgramData
    {
        //Class for our methods

        Program program = new Program();

        //Framtida metoder

        //public List<Program> PopluarProgram()
        //{
        //    Forechloop. Alla program i databasen => lägg till i programlista/ kanallista + per dag lista

        //}

        //public List<Program> PopluarProgram()
        //{
        //    Visa populära program i egen lista?
        //    Booleansk metod. true = rekomenderad. False = ej i rekomendeade listan ??

        //}



        //Metoder som kanske kommer ligga i andra klasser

        //Logga in (administratör och besökare)

        //Redigera populära program (lägga till/ta bort) - https://stackoverflow.com/questions/853526/using-linq-to-remove-elements-from-a-listt

        //Besökare ska kunna välja favoritkanaler

        //Hemsidan ska vara responsiv

        //url likt: tv/svt/svtplay



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