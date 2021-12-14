using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fak4ura.Models
{
    public class randomStr
    {
        public randomStr() 
        {
        }
        //random length
        public static string Generate()
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKlMNOPRSTUVWXYZ0123456789".ToCharArray();
            Random rnd = new Random();
            var result = new StringBuilder();
            for (int i = 0; i < rnd.Next(10, 18); i++)
                result.Append(alphabet[(rnd.Next(0, alphabet.Length))]);
            
            return result.ToString();
        }

        public static string Generate(int length)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKlMNOPRSTUVWXYZ0123456789".ToCharArray();
            Random rnd = new Random();
            var result = new StringBuilder();
            for (int i = 0; i < length; i++)
                result.Append(alphabet[(rnd.Next(0, alphabet.Length))]);

            return result.ToString();
        }
    }
}
