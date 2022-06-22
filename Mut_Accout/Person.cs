using Microsoft.Data.SqlClient;

namespace Accountability
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Url { get; set; }

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
