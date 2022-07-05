using Microsoft.Data.SqlClient;
using Mut_Accout;

namespace Mut_Accout1
{
    internal class AcctList
    {
        //Adding Activities to Database
        public static void NewAcct()
        {
            string? email1 = Mut_Accout.MemberInput.email;
            string connstring2 = System.Configuration.ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connstring2);
            string? acct;
            string? acct1;
            string? acct2;
            SqlDataReader? myReader = null;

            string query4 = @"INSERT INTO [Daily_Entry] (User_Email,Activite_1,Activite_2,Activite_3,Created_Date)  Values (@User_Email,@Acitivte_1,@Acitivte_2,@Acitivte_3,@Created_Date)";
            string query2 = @"Select * from [List_Activities]";

            Console.Clear();
            Logo.AcctLogo();
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine("List is the following Activities.");
            using SqlCommand cmd3 = new SqlCommand(query2, con);
            con.Open();
            myReader = cmd3.ExecuteReader();
            while (myReader.Read())
            {
                Console.WriteLine(myReader["DaliyActivites"].ToString());


            }
            con.Close();

            Console.WriteLine("\nPlease choose 3 daily Activities. Press Enter after each entry");
            Console.Write("Entry 1): ");
            acct = Console.ReadLine();
            Console.Write("Entry 2): ");
            acct1 = Console.ReadLine();
            Console.Write("Entry 3): ");
            acct2 = Console.ReadLine();



            using SqlCommand cmd4 = new SqlCommand(query4, con);
            {
                cmd4.Parameters.AddWithValue("@User_Email", email1);
                cmd4.Parameters.AddWithValue("@Acitivte_1", acct);
                cmd4.Parameters.AddWithValue("@Acitivte_2", acct1);
                cmd4.Parameters.AddWithValue("@Acitivte_3", acct2);
                cmd4.Parameters.AddWithValue("@Created_Date", DateTime.UtcNow);



                try
                {
                    con.Open();
                    cmd4.ExecuteNonQuery();
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
