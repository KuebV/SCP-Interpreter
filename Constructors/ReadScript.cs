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

        public ReadScript(int index)
        {
            IndexScript = index;
        }

        private string ScriptDirectory() => Path.Combine(Directory.GetCurrentDirectory(), "Scripts");
        private int IndexScript;
        public static IEnumerable<string> ScriptCommands;

        public void LoadScript()
        {
            string selectedFile = Path.Combine(ScriptDirectory(), ApplicationLaunch.Scripts.ElementAt(IndexScript));
            ScriptCommands = File.ReadLines(selectedFile);
        }
    }
}
