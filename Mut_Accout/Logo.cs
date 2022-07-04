
namespace Mut_Accout
 
{
    internal class Logo
    {
        public static void MainLogo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string mlogo = @"
______         _  _           ___         _    _         _  _    _            
|  _  \       (_)| |         / _ \       | |  (_)       (_)| |  (_)           
| | | |  __ _  _ | | _   _  / /_\ \  ___ | |_  _ __   __ _ | |_  _   ___  ___ 
| | | | / _` || || || | | | |  _  | / __|| __|| |\ \ / /| || __|| | / _ \/ __|
| |/ / | (_| || || || |_| | | | | || (__ | |_ | | \ V / | || |_ | ||  __/\__ \
|___/   \__,_||_||_| \__, | \_| |_/ \___| \__||_|  \_/  |_| \__||_| \___||___/
                      __/ |                                                   
                     |___/ ";
            Console.WriteLine(mlogo,Console.ForegroundColor);
        }
        public static void NewLogo()
        {
            Console.ForegroundColor= ConsoleColor.Red;
            string nlogo = @"
 _   _                  ___  ___                  _                 
| \ | |                 |  \/  |                 | |                
|  \| |  ___ __      __ | .  . |  ___  _ __ ___  | |__    ___  _ __ 
| . ` | / _ \\ \ /\ / / | |\/| | / _ \| '_ ` _ \ | '_ \  / _ \| '__|
| |\  ||  __/ \ V  V /  | |  | ||  __/| | | | | || |_) ||  __/| |   
\_| \_/ \___|  \_/\_/   \_|  |_/ \___||_| |_| |_||_.__/  \___||_| ";
            Console.WriteLine(nlogo,Console.ForegroundColor);
        }
        public static void AcctLogo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string alogo = @"
  ___         _    _         _  _    _                     _      _       _   
 / _ \       | |  (_)       (_)| |  (_)                   | |    (_)     | |  
/ /_\ \  ___ | |_  _ __   __ _ | |_  _   ___  ___         | |     _  ___ | |_ 
|  _  | / __|| __|| |\ \ / /| || __|| | / _ \/ __|        | |    | |/ __|| __|
| | | || (__ | |_ | | \ V / | || |_ | ||  __/\__ \        | |____| |\__ \| |_ 
\_| |_/ \___| \__||_|  \_/  |_| \__||_| \___||___/        \_____/|_||___/ \__|
                                                   ______                     
                                                  |______| ";
            Console.WriteLine(alogo,Console.ForegroundColor);   
        }
        public static void ReturnLogo()
        {
            Console.ForegroundColor=ConsoleColor.Green;
            string rlogo = @"
______        _                        _                ___  ___                  _                 
| ___ \      | |                      (_)               |  \/  |                 | |                
| |_/ /  ___ | |_  _   _  _ __  _ __   _  _ __    __ _  | .  . |  ___  _ __ ___  | |__    ___  _ __ 
|    /  / _ \| __|| | | || '__|| '_ \ | || '_ \  / _` | | |\/| | / _ \| '_ ` _ \ | '_ \  / _ \| '__|
| |\ \ |  __/| |_ | |_| || |   | | | || || | | || (_| | | |  | ||  __/| | | | | || |_) ||  __/| |   
\_| \_| \___| \__| \__,_||_|   |_| |_||_||_| |_| \__, | \_|  |_/ \___||_| |_| |_||_.__/  \___||_|   
                                                  __/ |                                             
                                                 |___/  ";
            Console.WriteLine(rlogo,Console.ForegroundColor);

        }
        public static void DataLogo()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string dlogo = @"
______         _  _         ______                                 _                       
|  _  \       (_)| |        | ___ \                               | |                      
| | | |  __ _  _ | | _   _  | |_/ / _ __   ___   ___   ___  _ __  | |_   __ _   __ _   ___ 
| | | | / _` || || || | | | |  __/ | '__| / _ \ / __| / _ \| '_ \ | __| / _` | / _` | / _ \
| |/ / | (_| || || || |_| | | |    | |   |  __/| (__ |  __/| | | || |_ | (_| || (_| ||  __/
|___/   \__,_||_||_| \__, | \_|    |_|    \___| \___| \___||_| |_| \__| \__,_| \__, | \___|
                      __/ |                                                     __/ |      
                     |___/                                                     |___/  ";
            Console.WriteLine(dlogo,Console.ForegroundColor);
        }
    }
}
