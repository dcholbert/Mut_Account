using Microsoft.Data.SqlClient;
using Mut_Accout1;
using Mut_Accout2;

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
            string? response3;
            string? entry1;
            string? entry2;
            string? entry3;


            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connstring);




            string query2 = @"Select * from [List_Activities]";

            string query4 = @"Select * from [Daily_Entry] Where User_Email LIKE '%" + email + "%' AND CONVERT(DATE,Created_Date)=CONVERT(Date,GETDATE())";
            string query5 = @"UPDATE [Daily_Entry] SET Entry1 = @Entry1, Entry2 = @Entry2, Entry3 = @Entry3 Where User_Email LIKE '%" + email + "%' AND CONVERT(DATE,Created_Date)=CONVERT(Date,GETDATE())";


            Console.WriteLine("Welcome Back! Please enter your Email.");
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

                AcctList.NewAcct();
                Console.WriteLine("Push enter to return to Main Menu.");
                Console.ReadLine();
                Startup.Run();

            }


            else if (response1 == "2")
            {

                Console.Clear();
                Console.WriteLine("Do you want to complete some of you activites\n");
                Console.WriteLine("1) Yes, To continue\n");
                Console.WriteLine("2) NO, Return to Main Menu\n");
                response3 = Console.ReadLine();
                if (response3 == "2")
                {
                    Startup.Run();
                }
                else if (response3 == "1")
                {
                    Console.WriteLine("Here is your Daily Entry for Today.");
                    Console.WriteLine("Please put (1) to complete and (0) or Blank for not Completed.\n");
                    ListDataTable.Dtable();

                    con.Close();
                    Console.Write("Entry 1):");
                    entry1 = Console.ReadLine();
                    Console.Write("Entry 2):");
                    entry2 = Console.ReadLine();
                    Console.Write("Entry 2):");
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

