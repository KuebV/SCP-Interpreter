using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP_Interpreter.Constructors
{
    public class ReadScript
    {
        /// <summary>
        /// Gets the specified Index, and reads the script accordingly
        /// </summary>
        /// <param name="index"></param>
        public ReadScript(int index)
        {
            IndexScript = index;
        }

        private string ScriptDirectory() => Path.Combine(Directory.GetCurrentDirectory(), "Scripts");
        private int IndexScript;

        /// <summary>
        /// Stores the Script Commands Locally and in Memory
        /// </summary>
        public static IEnumerable<string> ScriptCommands;

        public static string ScriptName;

        /// <summary>
        /// Loads the Selected Script by the Index
        /// </summary>
        public void LoadScript()
        {
            string selectedFile = Path.Combine(ScriptDirectory(), ApplicationLaunch.Scripts.ElementAt(IndexScript));
            ScriptCommands = File.ReadLines(selectedFile);

            ScriptName = ApplicationLaunch.Scripts.ElementAt(IndexScript);
        }
    }
}
