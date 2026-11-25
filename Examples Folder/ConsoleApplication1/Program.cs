   using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;


 public   class Program
    {

  

    static string connectionString="server=.;Database=ContactsDB;User Id=sa;Password=123456;";
    static void PrintallContacts() {

        SqlConnection Connection = new SqlConnection(connectionString);

        string query = "SELECT * FROM Contacts";
        SqlCommand command = new SqlCommand(query, Connection);
        try {

            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {

                if ((int)reader["ContactID"] == 1)
                {
                    int contactID = (int)reader["ContactID"];
                    string FirstNam = (string)reader["FirstName"];
                    string LastNam = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int counterID = (int)reader["CountryID"];


                    Console.WriteLine("Contact ID:{0}", contactID);
                    Console.WriteLine("Name: {0} {1}", FirstNam, LastNam);
                    Console.WriteLine("Email: {0} ", email);
                    Console.WriteLine("Phone: {0}", phone);
                    Console.WriteLine("Address: {0}", address);
                    Console.WriteLine("Country ID : {0}", counterID);

                    Console.WriteLine();
                }

            }
            reader.Close();
            Connection.Close();
        }
        catch (Exception ex) {


            Console.WriteLine("Error {0}", ex.Message);

        }
    }
   
        static void Main(string[] args)
        {
            PrintallContacts();
            Console.ReadKey();
        }
    }

