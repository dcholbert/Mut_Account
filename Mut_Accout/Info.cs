using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mut_Accout
{
    internal class Info
    { 
        public static void GetInfo()
        {
            
            using (StreamReader sr = new StreamReader(Path.Combine(Environment.CurrentDirectory, "infromation.txt")))
            {
                string line;
                while((line = sr.ReadLine()) != null)
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
