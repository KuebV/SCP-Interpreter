using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP_Interpreter.Constructors
{
    public class ExampleScript
    {
        public static void WriteExampleScript()
        {
            string mainDir = Directory.GetCurrentDirectory();

            string scripts = Path.Combine(mainDir, "Scripts");
            string script = "" +
                "encrypt-\n" +
                "decrypt-\n" +
                "quit\n";

            string exampleFile = Path.Combine(scripts, "example-script.tfto");
            File.WriteAllText(exampleFile, script);

        }
    }
}
