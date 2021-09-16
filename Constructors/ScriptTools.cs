using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP_Interpreter.Constructors
{
    public class ScriptTools
    {
        private static string ScriptDirectory() => Path.Combine(Directory.GetCurrentDirectory(), "Scripts");
        private static List<string> ScriptList = new List<string>();

        public static Dictionary<string, bool> ScriptResults = new Dictionary<string, bool>();

        public static void BuildScripts()
        {
            DirectoryInfo ScriptDirectoryInfo = new DirectoryInfo(ScriptDirectory());
            foreach (var script in ScriptDirectoryInfo.GetFiles())
            {
                if (script.Extension == ".tfto")
                {
                    if (!File.ReadAllText(script.FullName).Contains("return"))
                        File.AppendAllText(script.FullName, "\nreturn True");
                }
                  
                    
            }
        }

        public static void DebugScript()
        {
            DirectoryInfo ScriptDirectoryInfo = new DirectoryInfo(ScriptDirectory());
            foreach (var script in ScriptDirectoryInfo.GetFiles())
            {
                if (script.Extension == ".tfto")
                {
                    if (File.ReadAllText(script.FullName).Contains("return True"))
                        Console.WriteLine($"\nScript - {script.Name} has been debugged successfully!");
                    else
                        Console.WriteLine($"\nScript - {script.Name} has not been built!");
                }


            }
        }

    }
}
