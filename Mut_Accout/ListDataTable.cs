using Microsoft.Data.SqlClient;
using System.Data;

namespace Mut_Accout2
{
    internal class ListDataTable
    {
        public static void Dtable()
        {

            string? email1 = Mut_Accout.MemberInput.email;
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connstring);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(@"Select * from [Daily_Entry] Where User_Email LIKE '%" + email1 + "%' AND CONVERT(DATE,Created_Date)=CONVERT(Date,GETDATE())", con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine("User Details Are Following:");
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {

                }
                Console.WriteLine();
                for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                {
                    for (int curCol = 0; curCol < dt.Columns.Count; curCol++)

                    {
                        Console.Write(dt.Columns[curCol].ColumnName + ": \t");
                        Console.Write(dt.Rows[curRow][curCol].ToString() + "\n");
                    }
                    Console.WriteLine();

                }

            }
        }
    }
}
