using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;


public class Program
{



    static string connectionString = "server=.;Database=ContactsDB;User Id=sa;Password=123456;";


    static void DeleteContact(int ContactID)
    {

        SqlConnection Connection = new SqlConnection(connectionString);

       string query = @"DELETE FROM  Contacts WHERE ContactID=@ContactID";
       // string query = @"DELETE FROM  Contacts WHERE FirstName='ibrahim'";


        SqlCommand command = new SqlCommand(query, Connection);
       // command.Parameters.AddWithValue("@ContactID", ContactID);

        try
        {

            Connection.Open();
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {

                Console.WriteLine("Recorde deleted successfully");
            }
            else
            {
                Console.WriteLine("Recorde deletion Failed");


            }

            Connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error {0}", ex.Message);
        }

    }

    


    static void Main(string[] args)
    {

        DeleteContact(17);
     

        Console.ReadKey();
    }
}

