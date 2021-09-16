using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SCP_Interpreter.Constructors;

namespace SCP_Interpreter
{
    class Program
    {

        private static bool firstRun = true;
        static void Main(string[] args)
        {
            // Starting Application
            if (firstRun)
            {
                ApplicationLaunch launch = new ApplicationLaunch(true);
                launch.Launch();
            }

            Console.WriteLine("\nAvaliable Scripts");
            int index = 0;
            Console.WriteLine("-------------------");
            foreach (var file in ApplicationLaunch.Scripts)
            {
                Console.WriteLine($"[{index}] - {file}");
                index++;
            }

            Console.WriteLine("\n------- Other Options ---------");
            Console.WriteLine($"[{index + 2}] - Build All Scripts");
            Console.WriteLine($"[{index + 3}] - Compile and Debug Scripts");

            Console.WriteLine("\n\nEnter the number linked to the script");
            int selectedIndex = Convert.ToInt32(Console.ReadLine());

            if (selectedIndex == ApplicationLaunch.Scripts.Count + 2)
            {
                Console.Clear();
                Console.Write("Building Scripts ");

                for (int i = 0; i < ApplicationLaunch.Scripts.Count; i++)
                {
                    Console.Write(".");

                    // Woo for artifical delays
                    Thread.Sleep(1000);
                }

                firstRun = false;

                ScriptTools.BuildScripts();
                string[] arg = { "none" };
                Thread.Sleep(1000);
                Console.Clear();
                Main(arg);
            }

            if (selectedIndex == ApplicationLaunch.Scripts.Count + 3)
            {
                Console.Clear();
                Console.Write("Debugging Scripts ");
                for (int i = 0; i < ApplicationLaunch.Scripts.Count; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(1000);
                }

                firstRun = false;

                ScriptTools.DebugScript();
                string[] arg = { "none" };
                Thread.Sleep(3000);
                Console.Clear();
                Main(arg);

            }

            ReadScript readScript = new ReadScript(selectedIndex);
            readScript.LoadScript();

            ScriptActions.ExecuteScript();

            Console.ReadLine();
        }
    }
}
