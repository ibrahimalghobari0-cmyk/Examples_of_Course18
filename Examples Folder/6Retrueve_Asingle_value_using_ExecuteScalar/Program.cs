using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;


public class Program
{



    static string connectionString = "server=.;Database=ContactsDB;User Id=sa;Password=123456;";
    static string GetFirstName(int ContactID)
    {
        string FirstName = "";
        SqlConnection Connection = new SqlConnection(connectionString);

        string query = "SELECT FirstName from contacts where ContactID=@ContactID";
        SqlCommand command = new SqlCommand(query, Connection);
        command.Parameters.AddWithValue("@ContactID", ContactID);
        try
        {

            Connection.Open();
            //the result type is object because we don't know the type of the return vlaue
            object result = command.ExecuteScalar();

            if (result != null)
            {

                FirstName = result.ToString(); //we converted the reuslt into strign  because its type was object and we want to store a string value
            }
            else {

                FirstName = "";//if the result was null then we didn't find firstname of contactid 1 so firstname equlat nothing
            }
            Connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error {0}", ex.Message);
        }
        return FirstName;
    }


   

    static void Main(string[] args)
    {
        Console.WriteLine(GetFirstName(1));
       
        Console.ReadKey();
    }
}

