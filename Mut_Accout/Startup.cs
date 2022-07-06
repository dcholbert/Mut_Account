namespace Mut_Accout
{
    internal class Startup
    {
        public static void Run()
        {

            string? response;
            Console.Clear();
            Logo.MainLogo();
            Console.ResetColor();
            Console.WriteLine("Main Menu:\n");
            Console.WriteLine("1) New Member");
            Console.WriteLine("2) Returning Member");
            Console.WriteLine("3) Daily Precentage");
            Console.WriteLine("4) Info");
            Console.WriteLine("5) Exit\n");
            Console.Write("Where do you want to go?:");
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
            // Daily Goal Precentage
            else if (response == "3")
            {
                EntryMath.DaliyMath();
            }
            else if (response == "4")
            {
                //Add info selection
            }
            else if (response == "5")
            {//Add exit

            }
            else
            {
                Console.WriteLine("Nope! Try Again!");
                Console.Beep();
                Console.ReadLine();
                Run();
            }



        }


    }
}
