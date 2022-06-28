using Mut_Accout;


namespace Accountability
{
    class Program
    {
        static void Main(string[] vs)
        {



            string? response;

            Console.WriteLine("Are you a new or existing user?");
            Console.WriteLine("1) New Member");
            Console.WriteLine("2) Returning Member");
            Console.WriteLine("Please select the following:");
            response = Console.ReadLine();
            Console.Clear();

            // New Members
            if (response == "1")
            {

                MemberInput.NewMenber();

            }
            //Returning Member
            else if (response == "2")
            {

                MemberInput.ReturnMember();

            }
            else
            {
                Console.WriteLine("Nope! Try Again!");
                
            }
        }
    }
}




