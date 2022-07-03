using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mut_Accout
{
    internal class Startup
    {
        public static void Run()
        {

            string? response;
            Console.Clear();
            Console.WriteLine("Are you a New or Returning Member?");
            Console.WriteLine("1) New Member");
            Console.WriteLine("2) Returning Member");
            Console.WriteLine("3) Daliy Precentage");
            Console.WriteLine("4) Exit");
            Console.Write("Please select the following:");
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
                //Add exit
            }
            else
            {
                Console.WriteLine("Nope! Try Again!\n");
                Run();
            }



        }


    }
}
