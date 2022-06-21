namespace Accountability
{
    class Program
    {
        public static string email { get; set; }
        static void Main(string[] vs)
        {


            //string? acct;
            //string? acct1;
            //string? acct2;

            string? user;
            string? user2;
            string? response;
            string? response1;
            string filePath = @"C:\Users\david\source\repos\Mut_Accout\Mut_Accout\Profiles.txt"; //will have to path correctly if cloned
            string filePath2 = @"C:\Users\david\source\repos\Mut_Accout\Mut_Accout\Daily Profiles.txt"; //will have to path correctly if cloned
            string? date;
            date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            user = null;




            Console.WriteLine(" Are you a new or existing user? 1 - New or  2 - Extisting ");
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

                Console.WriteLine(" Will this be a new daily entry? 1 - Yes or 2 - No");
                response1 = Console.ReadLine();

                if (response1 == "1")
                {
                    AddAcctList();


                }
                if (response1 == "2")
                {

                    string[] profile = File.ReadAllLines(filePath2);



                }

            }
        }


        private static void AddAcctList()
        {
            string filePath1 = @"C:\Users\david\source\repos\Mut_Accout\Mut_Accout\Activities.txt"; //will have to path correctly if cloned
            string filePath2 = @"C:\Users\david\source\repos\Mut_Accout\Mut_Accout\Daily Profiles.txt";
            string? acct;
            string? acct1;
            string? acct2;
            string? date;
            date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");







            List<Activities> people = new List<Activities>();
            List<string> lines1 = File.ReadAllLines(filePath1).ToList();
            foreach (var line in lines1)
            {
                string[] entries = line.Split(' ');

                Activities newtask = new Activities();

                newtask.Task = entries[0];
                people.Add(newtask);
            }
            Console.WriteLine("List is the following Activities.");
            foreach (var person in people)
            {

                Console.WriteLine(person.Task);
            }
            Console.WriteLine("Please choose 3 daily Activities. Press Enter after each entry");
            acct = Console.ReadLine();
            acct1 = Console.ReadLine();
            acct2 = Console.ReadLine();

            if (acct != null && acct1 != null && acct2 != null && email != null)
            {
                List<AcctTask> AcTask = new List<AcctTask>();

                List<string> lines = File.ReadAllLines(filePath2).ToList();

                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');

                    AcctTask newAcct = new AcctTask();

                    newAcct.Date = entries[0];
                    newAcct.Email = entries[1];
                    newAcct.MutTask = entries[2];
                    newAcct.MutTask1 = entries[3];
                    newAcct.MutTask2 = entries[4];

                    AcTask.Add(newAcct);
                }
                Console.WriteLine("Read From text file");

                foreach (var task in AcTask)
                {
                    Console.WriteLine($"{task.Date}- {task.Email}: {task.MutTask} {task.MutTask1} {task.MutTask2}");
                }
                AcTask.Add(new AcctTask { Date = date, Email = email, MutTask = acct, MutTask1 = acct1, MutTask2 = acct2 });

                List<string> output = new List<string>();

                foreach (var task in AcTask)
                {
                    output.Add($"{task.Date},{task.Email},{task.MutTask},{task.MutTask1},{task.MutTask2}");

                }
                Console.WriteLine("Writing to text file");

                File.WriteAllLines(filePath2, output);
                Console.WriteLine("All entries enter");

                Console.ReadLine();

            }


        }
    }
}




