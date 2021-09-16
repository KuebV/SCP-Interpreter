using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP_Interpreter.Constructors
{
    public class ApplicationLaunch
    {
        public ApplicationLaunch(bool CheckDirectory)
        {
            checkDirs = CheckDirectory;
        }

        private bool checkDirs;
        public static List<string> Scripts = new List<string>();
        
        /// <summary>
        /// Method Used at the Application Launch
        /// </summary>
        public void Launch()
        {
            string mainDir = Directory.GetCurrentDirectory();
            string scripts = Path.Combine(mainDir, "Scripts");

            if (!Directory.Exists(scripts))
                Directory.CreateDirectory(scripts);

            DirectoryInfo ScriptDirectory = new DirectoryInfo(scripts);
            foreach(var potentialScript in ScriptDirectory.GetFiles())
            {
                if (potentialScript.Extension == ".tfto")
                    Scripts.Add(potentialScript.Name);
            }

            if (ScriptDirectory.GetFiles().Length <= 1)
            {
                string exampleFile = Path.Combine(scripts, "example-script.tfto");
                File.Create(exampleFile);
            }

            Console.WriteLine("There are " + ScriptDirectory.GetFiles().Length + " files in the Script Directory");
            Console.WriteLine(Scripts.Count + " useable scripts have been identified");
        }
    }
}
