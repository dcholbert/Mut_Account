using Microsoft.Data.SqlClient;
using Mut_Accout1;

namespace Mut_Accout
{
    internal class MemberInput
    {
        public static string? email { get; set; }
        public static void NewMenber()
        {
            //string email1 = Accountability.Program.email ;
            string? user;
            string? user2;
            user = null;
            user2 = null;
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connstring);

            string query = @"INSERT INTO [User] Values (@User_FirstName,@User_LastName,@User_Email)";
            string query3 = @"Select * from [User] Where User_Email = @User_Email";
            string query4 = @"Select * from [Daily_Entry] Where User_Email LIKE '%" + email + "%' AND CONVERT(DATE,Created_Date)=CONVERT(Date,GETDATE())";


            //First Name
            do
            {
                if (string.IsNullOrEmpty(user))
                {

                    Console.WriteLine("What is the First Name you wish to enter?");
                    user = Console.ReadLine();



                }
                Console.WriteLine("User cannot be blank\n");
            } while (string.IsNullOrEmpty(user));
            Console.Clear();
            //Last Name
            do
            {
                if (string.IsNullOrEmpty(user2))
                {

                    Console.WriteLine("What is the Last Name you wish to enter?");
                    user2 = Console.ReadLine();



                }
                Console.WriteLine("User cannot be blank\n");
            } while (string.IsNullOrEmpty(user2));
            Console.Clear();
            //Email
            do
            {
                if (string.IsNullOrEmpty(email))
                {

                    Console.WriteLine("What Eamil do you wish to enter?");
                    email = Console.ReadLine();



                }
                Console.WriteLine("User cannot be blank\n");
            } while (string.IsNullOrEmpty(email));
            Console.Clear();

            con.Open();
            using (SqlCommand cmd = new SqlCommand(query3, con))
            {
                cmd.Parameters.AddWithValue("@User_Email", email);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                do
                {

                    if (reader.HasRows)
                    {
                        
                        Console.WriteLine("This " + email + " has already have been entered please submit a different email.");
                        Console.WriteLine("Please Enter new Email.");
                        email = Console.ReadLine();
                       


                    }
                    break;

                } while (reader.HasRows);
            }
            con.Close();

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

            AcctList.NewAcct();
            Console.WriteLine("Push enter to return to Main Menu.");
            Console.ReadLine();
            Startup.Run();


        }
        public static void ReturnMember()
        {


            string? response1;



            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connstring);
            SqlDataReader? myReader = null;
            SqlDataReader? myReader2 = null;



            string query2 = @"Select * from [List_Activities]";

            string query4 = @"Select * from [Daily_Entry] Where User_Email LIKE '%" + email + "%' AND CONVERT(DATE,Created_Date)=CONVERT(Date,GETDATE())";


            Console.WriteLine("Welcome Back! Please enter your email name.");
            email = Console.ReadLine();

            do
            {
                if (string.IsNullOrEmpty(email))
                {

                    Console.WriteLine("Please enter an Eamil.");
                    email = Console.ReadLine();



                }
                Console.WriteLine("Email cannot be blank\n");

            } while (string.IsNullOrEmpty(email));
            Console.Clear();

            Console.WriteLine("Will this be a new daily entry? 1 - Yes or 2 - No");
            response1 = Console.ReadLine();

            if (response1 == "1")
            {
                //Console.WriteLine("\nList is the following Activities.");
                //using SqlCommand cmd3 = new SqlCommand(query2, con);
                //con.Open();
                //myReader = cmd3.ExecuteReader();
                //while (myReader.Read())
                //{
                //    Console.WriteLine(myReader["DaliyActivites"].ToString());


                //}
                //con.Close();
                AcctList.NewAcct();
                Console.WriteLine("Push enter to return to Main Menu.");
                Console.ReadLine();
                Startup.Run();

            }


            else if (response1 == "2")
            {
                Console.WriteLine("Here is your Daily Entry for Today.");
                using SqlCommand cmd4 = new SqlCommand(query4, con);
                con.Open();
                myReader2 = cmd4.ExecuteReader();
                while (myReader2.Read())
                {
                    for (int i = 0; i < myReader2.FieldCount; i++)
                    {
                        Console.WriteLine(myReader2[i] + "    ");
                    }
                    Console.WriteLine();
                }
                con.Close();

                Console.WriteLine("Do you want to complete some of you activites");





            }



        }
    }

}

