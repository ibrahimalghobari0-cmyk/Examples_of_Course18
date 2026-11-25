using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;


public class Program
{



    static string connectionString = "server=.;Database=ContactsDB;User Id=sa;Password=123456;";
    static void SearchContactsStartWith(string StartsWith)
    {

        SqlConnection Connection = new SqlConnection(connectionString);

        string query = "SELECT * FROM Contacts where FirstName like '' +@StartsWith+'%'";
        SqlCommand command = new SqlCommand(query, Connection);
        command.Parameters.AddWithValue("@StartsWith", StartsWith);
        try
        {

            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
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
            reader.Close();
            Connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error {0}", ex.Message);
        }
    }


    static void SearchContactsEndsWith(string EndsWith)
    {

        SqlConnection Connection = new SqlConnection(connectionString);

        string query = "SELECT * FROM Contacts where FirstName like '%' +@EndsWith+''";
        SqlCommand command = new SqlCommand(query, Connection);
        command.Parameters.AddWithValue("@StartsWith", EndsWith);
        try
        {

            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
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
            reader.Close();
            Connection.Close();
        }
        catch (Exception ex)
        {


            Console.WriteLine("Error {0}", ex.Message);

        }
    }
    static void SearchContactsContains(string Contains)
    {

        SqlConnection Connection = new SqlConnection(connectionString);

        //to use the like with sql query  like ''+@variablename+'' inside the '' we could leave it empty or use the % inside it to search for somthing
        string query = "SELECT * FROM Contacts where FirstName like '%' +@Contains+'%'";
        
        SqlCommand command = new SqlCommand(query, Connection);
        //the comomand.parameters.addwithvaluse("@nameofthevaluethatweusedinsidetheSqlQuery",nameofthevariable)
        //the nameofthevaribale could be a variable or a value like .addwithvalue("@contains","j")
        //we only use it to supply the command with the parameter that we used inside the sql query
        //to sum up we only use it when we have parameters inside the sql query to we could supply the valuse to tthose parameters
        command.Parameters.AddWithValue("@Contains", Contains);
        try
        {

            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
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
            reader.Close();
            Connection.Close();
        }
        catch (Exception ex)
        {


            Console.WriteLine("Error {0}", ex.Message);

        }
    }


    static void Main(string[] args)
    {
        //Console.WriteLine("_____Contacts starts with 'j'");
        //SearchContactsStartWith("j");

        //Console.WriteLine("_____Contacts Ends with 'm'");

        //SearchContactsEndsWith("m");


        Console.WriteLine("_____Contacts Contains 'ane'");

        SearchContactsContains("ane");
        Console.ReadKey();
    }
}

