using System.Text.RegularExpressions;


namespace Mut_Accout
{
    internal class EmailValid
    {    //Validates an email address
        public static void ValidateEmail()
        {
            Mut_Accout.MemberInput.Email = Console.ReadLine();
            string email = Mut_Accout.MemberInput.Email;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                Console.WriteLine(email + " is Valid Email Address");
                return;

            }

            else
                Console.WriteLine(email + " is Invalid Email Address");
            ValidateEmail();
        }


    }
}
