using Microsoft.Data.SqlClient;
using System.Configuration;


namespace Accountability
{
    class Program
    {
        public static string email { get; set; }
        static void Main(string[] vs)
        {


            string? user;
            string? user2;
            string? response;
            string? response1;
            user = null;
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connstring);
            SqlDataReader? myReader = null;
            string query = @"INSERT INTO [User] Values (@User_FirstName,@User_LastName,@User_Email)";
            string query2 = @"Select * from [List_Activities]";
            string query3 = @"Select * from [User] Where User_Email = @User_Email";

            Console.WriteLine(" Are you a new or existing user? 1 - New or  2 - Extisting ");

            response = Console.ReadLine();



            // New Members
            if (response == "1")
            {
                Console.WriteLine("What is the First name you wish to enter?");
                user = Console.ReadLine();
                Console.WriteLine("What is the Last name you wish to enter?");
                user2 = Console.ReadLine();
                Console.WriteLine("What email do you want to go with your profile.");
                email = Console.ReadLine();



                if (string.IsNullOrEmpty(user))
                {

                    Console.WriteLine("User cannot be blank");


                }
                
                if (user != null && email != null && user2 != null)
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query3, con))
                    {
                        cmd.Parameters.AddWithValue("@User_Email", email);
                        SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


                        if (reader.HasRows)
                        {
                            Console.WriteLine("This " + email + " has already have been entered please submit a different email.");

                        }
                        else
                        {
                            using SqlCommand cmd2 = new SqlCommand(query, con);
                            {
                                cmd2.Parameters.AddWithValue("@User_FirstName", user);
                                cmd2.Parameters.AddWithValue("@User_LastName", user2);
                                cmd2.Parameters.AddWithValue("@User_Email", email);

                                try
                                {
                                    con.Open();
                                    cmd2.ExecuteNonQuery();
                                    Console.WriteLine("Records Inserted Successfully");
                                }
                                catch (SqlException e)
                                {
                                    Console.WriteLine("Error Generated Details:" + e.ToString());
                                }
                                finally
                                {
                                    con.Close();
                                    Console.ReadKey();
                                }
                            }

                            AddAcctList();

                        }

                    }
                    
                }
            }
            //Returning Member
            else if (response == "2")
            {


                Console.WriteLine("Welcome Back! Please enter your email name.");
                email = Console.ReadLine();

                if (string.IsNullOrEmpty(email))
                {

                    Console.WriteLine("User cannot be blank");


                }

                Console.WriteLine(" Will this be a new daily entry? 1 - Yes or 2 - No");
                response1 = Console.ReadLine();

                if (response1 == "1")
                {
                    Console.WriteLine("List is the following Activities.");
                    using SqlCommand cmd3 = new SqlCommand(query2, con);
                    con.Open();
                    myReader = cmd3.ExecuteReader();
                    while (myReader.Read())
                    {
                        Console.WriteLine(myReader["DaliyActivites"].ToString());

                    }
                    con.Close();

                    AddAcctList();


                }
                if (response1 == "2")
                {

                    



                }

            }
        }

        // Adding list of Actinitivties to Daily Reocrd
        public static void AddAcctList()
        {
            string connstring2 = System.Configuration.ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connstring2);
            string? acct;
            string? acct1;
            string? acct2;
            //var local = DateTime.Now;
            //var utc = local.ToUniversalTime();

            string query4 = @"INSERT INTO [Daily_Entry] Values (@User_Email,@Acitivte_1,@Acitivte_2,@Acitivte_3,GETDATE())";

            Console.WriteLine("Please choose 3 daily Activities. Press Enter after each entry");
            acct = Console.ReadLine();
            acct1 = Console.ReadLine();
            acct2 = Console.ReadLine();

            if (acct != null && acct1 != null && acct2 != null && email != null)
            {
                using SqlCommand cmd3 = new SqlCommand(query4, con);
                {
                    cmd3.Parameters.AddWithValue("@User_Email", email);
                    cmd3.Parameters.AddWithValue("@Acitivte_1", acct);
                    cmd3.Parameters.AddWithValue("@Acitivte_2", acct1);
                    cmd3.Parameters.AddWithValue("@Acitivte_3", acct2);
                   


                    try
                    {
                        con.Open();
                        cmd3.ExecuteNonQuery();
                        Console.WriteLine("Records Inserted Successfully");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Error Generated Details:" + e.ToString());
                    }
                    finally
                    {
                        con.Close();
                        Console.ReadKey();
                    }

                }



            }


        }


    }
}




