using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class IDGenerator
    {
        private static Random random = new Random();

        public static string GenerateRandomId(int length)
        {
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] id = new char[length];

            for (int i = 0; i < length; i++)
            {
                id[i] = chars[random.Next(chars.Length)];
            }

            return new string(id);
        }
    }
}
