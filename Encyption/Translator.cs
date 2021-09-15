using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP_Interpreter.Encyption
{
    public class Translator
    {

        public static string HumanToSCP(string message)
        {
            List<char> AlphabetChar = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
            'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

            string builder = string.Empty;
            foreach (char charLetter in message.ToLower())
            {
                if (!char.IsLetterOrDigit(charLetter))
                    builder += $" ";
                else
                {
                    int index = AlphabetChar.IndexOf(charLetter);
                    string character = AlphabetList.SCPNumber[index];

                    builder += $" {character}";
                }
            }

            return builder;


        }

        public static string SCPToHuman(string message)
        {
            List<char> AlphabetChar = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
            'm', 'n', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
            string builder = string.Empty;

            string[] scpMessage = message.Split(' ');
            foreach (var letter in scpMessage)
            {
                int index = AlphabetList.SCPNumber.IndexOf(letter);
                char charater = AlphabetChar[index];


                builder += $"{charater}";
            }

            return builder;
        }
    }
}