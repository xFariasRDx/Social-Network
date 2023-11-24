using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Helpers
{
    public class GeneratePassword
    {
        public static string RandomPassword(int otrapassword)
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new();

            char[] chars = new char[otrapassword];
            for (int i = 0; i < otrapassword; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new(chars);
        }

    }
}

