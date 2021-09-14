using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP_Interpreter.Constructors
{
    public class ScriptActions
    {
        /// <summary>
        /// Executes all given Commands in the Script
        /// </summary>
        public static void ExecuteScript()
        {
            Dictionary<string, dynamic> Variables = new Dictionary<string, dynamic>();

            foreach (var command in ReadScript.ScriptCommands)
            {
                string[] cmdVar = command.Split(' ');
                switch (cmdVar.ElementAt(0))
                {
                    case "var":
                        if (command.Contains("\""))
                        {
                            string strVar = String.Join(" ", cmdVar, 2, cmdVar.Length - 2);
                            Variables.Add(cmdVar.ElementAt(1), strVar);
                        }
                        else
                            Variables.Add(cmdVar.ElementAt(1), cmdVar.ElementAt(2));
                        break;
                    case "print":
                        if (Variables.ContainsKey(cmdVar.ElementAt(1)))
                        {
                            dynamic variable;
                            if (Variables.TryGetValue(cmdVar.ElementAt(1), out variable))
                                Console.WriteLine(variable);
                        }
                        else
                            Console.WriteLine(cmdVar.ElementAt(1));
                        break;
                    default:
                        Console.WriteLine("Unknown Type : " + cmdVar.ElementAt(0));
                        break;
                }

            }

        }
    }
}
