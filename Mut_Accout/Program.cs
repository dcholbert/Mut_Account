namespace Accountability
{
    class Program
    {
        static void Main(string[] vs)
        {
            string? email;
            string? response1;
            string? user;
            string? user2;
            string? response;
            string filePath = @"C:\Users\david\source\repos\Mut_Accout\Mut_Accout\Profiles.txt"; //will have to path correctly if cloned
            string? date;

            date = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");

            Console.WriteLine(date + " Are you a new or existing user? 1 - New or  2 - Extisting ");
            response = Console.ReadLine();
            if (response == "1")
            {
                Console.WriteLine("What is the First name you wish to enter?");
                user = Console.ReadLine();
                Console.WriteLine("What is the Last name you wish to enter?");
                user2 = Console.ReadLine();
                Console.WriteLine("What email do you want to go with your profile.");
                email = Console.ReadLine();



                if (string.IsNullOrEmpty(user))
                {

                    Console.WriteLine("User cannot be blank");

                }


                if (user != null && email != null && user2 != null)
                {
                    if (File.ReadAllText(filePath).Contains(email))
                    {
                        Console.WriteLine("This " + email + " has already have been entered please submit a different email.");

                    }
                    else
                    {
                        List<Person> people = new List<Person>();

                        List<string> lines = File.ReadAllLines(filePath).ToList();

                        foreach (var line in lines)
                        {
                            string[] entries = line.Split(',');

                            Person newPerson = new Person();

                            newPerson.FirstName = entries[0];
                            newPerson.LastName = entries[1];
                            newPerson.Url = entries[2];

                            people.Add(newPerson);
                        }
                        Console.WriteLine("Read From text file");

                        foreach (var person in people)
                        {
                            Console.WriteLine($"{person.FirstName} {person.LastName}: {person.Url}");
                        }
                        people.Add(new Person { FirstName = user, LastName = user2, Url = email });

                        List<string> output = new List<string>();

                        foreach (var person in people)
                        {
                            output.Add($"{person.FirstName},{person.LastName},{person.Url}");

                        }
                        Console.WriteLine("Wring to text file");

                        File.WriteAllLines(filePath, output);
                        Console.WriteLine("All entries enter");

                        Console.ReadLine();
                    }
                }
            }
            else if (response == "2")
            {
                Console.WriteLine("Welcome Back! Please enter your email name.");
                email = Console.ReadLine();

                if (string.IsNullOrEmpty(email))
                {

                    Console.WriteLine("User cannot be blank");

                }
                Console.WriteLine("Will this be a new daily entry? 1 - Yes or 2 - No");
                response1 = Console.ReadLine();

                if (response1 == "1")
                {
                    AcctList();


                }

            }



        }


        private static void AcctList()
        {
            string filePath1 = @"C:\Users\david\source\repos\Mut_Accout\Mut_Accout\Activities.txt"; //will have to path correctly if cloned

            List<Activities> people = new List<Activities>();
            List<string> lines1 = File.ReadAllLines(filePath1).ToList();
            foreach (var line in lines1)
            {
                string[] entries = line.Split(' ');

                Activities newtask = new Activities();

                newtask.Task = entries[0];
                people.Add(newtask);
            }
            //Console.WriteLine("Read From text file");

            foreach (var person in people)
            {
                Console.WriteLine(person.Task);
            }


        }
    }
}

