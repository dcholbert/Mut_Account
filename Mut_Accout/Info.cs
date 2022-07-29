namespace Mut_Accout
{
    internal class Info
    {
        public static void GetInfo()
        {//reads information.txt file

            using (StreamReader sr = new StreamReader(Path.Combine(Environment.CurrentDirectory, "infromation.txt")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine("\nPush enter to return to Main Menu.");
            Console.ReadLine();
            Startup.Run();

        }
    }

}
