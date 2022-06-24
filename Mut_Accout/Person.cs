using Microsoft.Data.SqlClient;

namespace Accountability
{
    public class Mycard
    {
        public string UserEmail { get; set; }
        public string Acct1 { get; set; }
        public string Acct2 { get; set; }
        public string Acct3 { get; set; }
        public string GetDate { get; set; }

    }
    public class Activities
    {
        public string Task { get; set; }

    }
    public class AcctTask
    {
        public string MutTask { set; get; }
        public string MutTask1 { get; set; }
        public string MutTask2 { get; set; }  
        public string Email { get; set; }
        public string Date { get; set; }

    }
   

    
}
