using Microsoft.Data.SqlClient;
using Mut_Accout1;
using Mut_Accout2;
using System.Text.RegularExpressions;

namespace Mut_Accout
{
    internal class MemberInput
    {
        public static string? Email { get; set; }
        public static void NewMenber()
        {
            //Added new members to the app
            string? email = Email;  
            string? user;
            string? user2;
            user = null;
            user2 = null;
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connstring);

            string query = @"INSERT INTO [User] Values (@User_FirstName,@User_LastName,@User_Email)";
            string query3 = @"Select * from [User] Where User_Email = @User_Email";
            string query4 = @"Select * from [Daily_Entry] Where User_Email LIKE '%" + Email + "%' AND CONVERT(DATE,Created_Date)=CONVERT(Date,GETDATE())";

            Logo.NewLogo();
            Console.ResetColor();
            Console.WriteLine();
            //First Name
            do
            {
                if (string.IsNullOrEmpty(user))
                {

                    Console.Write("First Name: ");
                    user = Console.ReadLine();



                }
                else
                    Console.WriteLine("User cannot be blank\n");
            } while (string.IsNullOrEmpty(user));

            //Last Name
            do
            {
                if (string.IsNullOrEmpty(user2))
                {

                    Console.Write("Last Name: ");
                    user2 = Console.ReadLine();



                }
                else
                    Console.WriteLine("User cannot be blank\n");
            } while (string.IsNullOrEmpty(user2));

            //Email
            Console.Write("Eamil: ");
            EmailValid.ValidateEmail();



            con.Open();
            using (SqlCommand cmd = new SqlCommand(query3, con))
            {
                cmd.Parameters.AddWithValue("@User_Email", Email);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                do
                {

                    if (reader.HasRows)
                    {

                        Console.WriteLine("This " + Email + " has already have been entered please submit a different email.");
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
                cmd2.Parameters.AddWithValue("@User_Email", Email);

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
            // Returning Members to enter new or view existing events

            string? response1;
            string? response3;
            string? response4;

            string? entry1;
            string? entry2;
            string? entry3;



            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connstring);






            string query4 = @"Select * from [Daily_Entry] Where User_Email LIKE '%" + Email + "%' AND CONVERT(DATE,Created_Date)=CONVERT(Date,GETDATE())";
            string query5 = @"UPDATE [Daily_Entry] SET Entry1 = @Entry1, Entry2 = @Entry2, Entry3 = @Entry3 Where User_Email LIKE '%" + Email + "%' AND CONVERT(DATE,Created_Date)=CONVERT(Date,GETDATE())";


            Console.Clear();
            if (Email == null)
            {
                Logo.ReturnLogo();
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("Please enter Email: ");
                EmailValid.ValidateEmail();
                Console.Clear();
            }

            Console.Clear();
            Logo.ReturnLogo();
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Welcome Back!\t");
            Console.WriteLine(Email); //Add User First and Last instead of email

            Console.WriteLine("\nDaily Entry:");
            Console.WriteLine("1) New Daily Entries");
            Console.WriteLine("2) Complete Entries\n");
            Console.Write("Enter your selection here: ");
            response1 = Console.ReadLine();

            if (response1 == "1")
            {

                AcctList.NewAcct();
                Console.WriteLine("Push enter to return to Main Menu.");
                Console.ReadLine();
                Startup.Run();

            }


            else if (response1 == "2")
            {

                Console.Clear();
                Logo.ReturnLogo();
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Do you want to view activites:");
                Console.WriteLine("1) To continue");
                Console.WriteLine("2) Return to Main Menu\n");
                Console.Write("Enter your selection here: ");
                response3 = Console.ReadLine();
                if (response3 == "2")
                {
                    Startup.Run();
                }
                else if (response3 == "1")//Add loop for inputs
                {
                    Console.Clear();
                    Logo.ReturnLogo();
                    Console.ResetColor();
                    Console.WriteLine("Here is your Daily Entry for Today.");
                    ListDataTable.Dtable();
                    Console.WriteLine("Do you still want to Continue?");
                    Console.WriteLine("1) Continue");
                    Console.WriteLine("2) Return to Main Menu.");
                    Console.Write("Select from Above: ");
                    response4 = Console.ReadLine();
                    if (response4 == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("Returing to Main Menu");
                        Console.WriteLine();
                        Startup.Run();
                    }
                    else if (response4 == "1")
                    {
                        Console.Clear();
                        ListDataTable.Dtable();

                        Console.WriteLine("Please put (1) to Complete and (0) Not Completed.\n");



                        //Add Loop so only inputs are correct
                        Console.Write("Activity 1): ");
                        entry1 = Console.ReadLine();
                        Console.Write("Activity 2): ");
                        entry2 = Console.ReadLine();
                        Console.Write("Activity 3): ");
                        entry3 = Console.ReadLine();
                        using SqlCommand cmd5 = new SqlCommand(query5, con);
                        {
                            cmd5.Parameters.AddWithValue("@Entry1", entry1);
                            cmd5.Parameters.AddWithValue("@Entry2", entry2);
                            cmd5.Parameters.AddWithValue("@Entry3", entry3);



                            try
                            {
                                con.Open();
                                cmd5.ExecuteNonQuery();
                                Console.WriteLine("Records Inserted Successfully");
                            }
                            catch (SqlException e)
                            {
                                Console.WriteLine("Error Generated Details:" + e.ToString());
                            }
                            finally
                            {
                                con.Close();
                                Console.WriteLine("Push enter to return to Main Menu.");
                                Console.ReadLine();
                                Startup.Run();
                            }
                        }
                    }
                }

            }
        }

    }

}

