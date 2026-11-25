using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;


public class Program
{



    static string connectionString = "server=.;Database=ContactsDB;User Id=sa;Password=123456;";



    static bool FindContactByID(int ContactID, ref stContact ContactInfo) {


        bool isFound = false;
         SqlConnection Connection = new SqlConnection(connectionString);

        string query = "SELECT * from Contacts where ContactID=@ContactID";
        SqlCommand command = new SqlCommand(query, Connection);
        command.Parameters.AddWithValue("@ContactID", ContactID);
        try
        {

            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                isFound = true;
                ContactInfo.ID = (int)reader["ContactID"];
                ContactInfo.FirstName = (string)reader["FirstName"];
                ContactInfo.LastName = (string)reader["LastName"];
                ContactInfo.Email = (string)reader["Email"];
                ContactInfo.Phone = (string)reader["Phone"];
                ContactInfo.Address = (string)reader["Address"];
                ContactInfo.CountryID = (int)reader["CountryID"];



                Console.WriteLine();


            }
            else {

                isFound = false;
            }
            reader.Close();
            Connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error {0}", ex.Message);
            }
        return isFound;
            

    }
    public struct stContact {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryID { get; set; }
    }


    static void Main(string[] args)
    {

        stContact ContactInfo = new stContact();

        if (FindContactByID(1, ref ContactInfo))
        {
            Console.WriteLine("Contact ID:{0}", ContactInfo.ID);
            Console.WriteLine("Name: {0} {1}", ContactInfo.FirstName, ContactInfo.LastName);
            Console.WriteLine("Email: {0} ", ContactInfo.Email);
            Console.WriteLine("Phone: {0}", ContactInfo.Phone);
            Console.WriteLine("Address: {0}", ContactInfo.Address);
            Console.WriteLine("Country ID : {0}", ContactInfo.CountryID);
        } Console.ReadKey();
    }
}

