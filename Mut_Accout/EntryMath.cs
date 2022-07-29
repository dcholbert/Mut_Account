using Microsoft.Data.SqlClient;
using System.Data;



namespace Mut_Accout
{
    internal class EntryMath
    {
        public static void DaliyMath()
        {
            double percentage = 0;

            string email1 = Mut_Accout.MemberInput.Email;
            DataTable dt = new DataTable();
            string connstring2 = System.Configuration.ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connstring2);

            string query6 = @"Select SUM(Entry1+Entry2+Entry3) As percentage From [Daily_Entry] Where User_Email LIKE '%" + email1 + "%' AND CONVERT(DATE,Created_Date)=CONVERT(Date,GETDATE())";
            Console.Clear();
            Logo.DataLogo();
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Welcome Back!");
            if (email1 == null)
            {
                Console.Write("Please enter Email: ");
                EmailValid.ValidateEmail();
            }
            Console.Clear();
            Logo.DataLogo();
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Welcome Back!\t");
            Console.WriteLine(Mut_Accout.MemberInput.Email); //Add User First and Last instead of email

            con.Open();
            using SqlCommand cmd = new SqlCommand(query6, con);
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {

                    percentage = (double)Convert.ToDecimal(dr[0]);
                }
                Console.WriteLine("You are " + percentage + " out of 3 for the day.\n");
                Console.Write("Here is you Daliy Precentage:\t");
                Console.WriteLine(Math.Round((percentage / 3) * 100, 2) + "%\n"); //Add Submit to new database for future records
            }

            catch (Exception e)
            {
                //Console.WriteLine("Error Generated Details:" + e.ToString());

                Console.WriteLine("There is no Entries Added to Calculate");
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
