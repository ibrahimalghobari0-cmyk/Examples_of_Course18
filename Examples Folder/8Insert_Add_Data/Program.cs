using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;


public class Program
{



    static string connectionString = "server=.;Database=ContactsDB;User Id=sa;Password=123456;";


    static void AddNewContact(stContact newContact) {

        SqlConnection Connection = new SqlConnection(connectionString);

        string query = "INSERT INTO Contacts(FirstName,LastName,Email,Phone,Address,CountryID) VALUES(@FirstName,@LastName,@Email,@Phone,@Address,@CountryID); select SCOPE_IDENTITY();";
        SqlCommand command = new SqlCommand(query, Connection);
        command.Parameters.AddWithValue("@FirstName", newContact.FirstName);
        command.Parameters.AddWithValue("@LastName", newContact.LastName);
        command.Parameters.AddWithValue("@Email", newContact.Email);
        command.Parameters.AddWithValue("@Phone", newContact.Phone);
        command.Parameters.AddWithValue("@Address", newContact.Address);
        command.Parameters.AddWithValue("@CountryID", newContact.CountryID);

   
        try
        {

            Connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
          
            if (rowsAffected>0)
            {
                Console.WriteLine(rowsAffected);

                Console.WriteLine("Record Inserted Successfully");
            }
            else
            {
                Console.WriteLine("Record Insertion Failed");


            }
          
            Connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error {0}", ex.Message);
        }
        
    }

    public struct stContact
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryID { get; set; }
    }


    static void Main(string[] args)
    {

        stContact ContactInfo = new stContact {
        
        FirstName="ibrahim",
        LastName="Alghobari",
        Email="ibrahimalghobari0@gmail.com",
        Phone="+967781757285",
        Address="Ibb City,Alsabel Venue",
        CountryID=1

        };
        AddNewContact(ContactInfo);

    Console.ReadKey();
    }
}

