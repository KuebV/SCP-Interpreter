using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCP_Interpreter.Encyption;

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
                ArraySegment<string> arguments = new ArraySegment<string>(cmdVar);
                switch (arguments.At(0))
                {
                    case "var":
                        if (Variables.ContainsKey(cmdVar.ElementAt(1)))
                        {
                            Variables.Remove(cmdVar.ElementAt(1));
                        }
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
                    case "input":
                        if (command.Contains("\""))
                        {
                            string strVar = String.Join(" ", cmdVar, 2, cmdVar.Length - 2);
                            Console.WriteLine(strVar);

                            var variable = Console.ReadLine();
                            Variables.Add(cmdVar.ElementAt(1), variable);
                        }
                        break;
                    case "translate":
                        if (command.Contains("\""))
                        {
                            string strVar = String.Join(" ", cmdVar, 2, cmdVar.Length - 2);
                            string language = Translator.HumanToSCP(strVar.Replace("\"", ""));

                            Variables.Add(cmdVar.ElementAt(1), language);
                        }
                        break;
                    case "varint":
                        double varint;
                        if (double.TryParse(cmdVar.ElementAt(2), out varint))
                            Variables.Add(cmdVar.ElementAt(1), varint);
                            
                        break;
                    case "return":
                        bool result;
                        if (Boolean.TryParse(arguments.At(1), out result))
                        {
                            ScriptTools.ScriptResults.Add(ReadScript.ScriptName, result);
                        }
                        break;
                    default:
                        if (string.IsNullOrEmpty(command))
                            break;
                        else
                            Console.WriteLine("Unknown Type : " + cmdVar.ElementAt(0));
                        break;

                }

            }

        }
    }
}
