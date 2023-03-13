using System;
using System.Linq;

namespace GymManager.Common.Extensions
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input)
        {
            return input switch
            {
                null => null,
                "" => "",
                _ => input[0].ToString().ToUpper() + (input.Length > 1 ? input[1..].ToLower() : "")
            };
        }

        public static byte[] ToByteArray(this string hex, int lenght = -1)
        {
            if (lenght > 0)
            {
                hex = hex.PadLeft(lenght * 2, '0');
            }

            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }
    }
}