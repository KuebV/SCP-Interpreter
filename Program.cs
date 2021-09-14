using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCP_Interpreter.Constructors;

namespace SCP_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Starting Application
            ApplicationLaunch launch = new ApplicationLaunch(true);
            launch.Launch();

            Console.WriteLine("\nAvaliable Scripts");
            int index = 0;
            Console.WriteLine("-------------------");
            foreach (var file in ApplicationLaunch.Scripts)
            {
                Console.WriteLine($"[{index}] - {file}");
                index++;
            }

            Console.WriteLine("\n\nEnter the number linked to the script");
            int selectedIndex = Convert.ToInt32(Console.ReadLine());

            ReadScript readScript = new ReadScript(selectedIndex);
            readScript.LoadScript();

            ScriptActions.ExecuteScript();

            Console.ReadLine();
        }
    }
}
