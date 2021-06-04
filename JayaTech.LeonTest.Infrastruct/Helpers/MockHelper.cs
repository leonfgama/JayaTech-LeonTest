using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace JayaTech.LeonTest.Infrastruct.Helpers
{
    public class MockHelper
    {
        private const string CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private const string CHARS_NO_NUMBERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string CHARS_NUMBERS = "1234567890";

        private static Random random = new Random();

        public static string GenerateRandomString(int length, bool hasNumbers = false, StringCaseStyle caseStyle = StringCaseStyle.None)
        {
            string generatedString = string.Empty;
            if (hasNumbers)
                generatedString = new string(Enumerable.Repeat(CHARS, length).Select(s => s[random.Next(s.Length)]).ToArray());
            else
                generatedString = new string(Enumerable.Repeat(CHARS_NO_NUMBERS, length).Select(s => s[random.Next(s.Length)]).ToArray());


            switch (caseStyle)
            {
                case StringCaseStyle.TitleCase:
                    generatedString = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(generatedString);
                    break;
                case StringCaseStyle.UpperCase:
                    generatedString = generatedString.ToUpper();
                    break;
                case StringCaseStyle.LowerCase:
                    generatedString = generatedString.ToLower();
                    break;
                case StringCaseStyle.EmailCase:
                    generatedString = string.Concat(generatedString, "@gmail.com.br").ToLower();
                    break;
                default:
                    break;
            }

            return generatedString;
        }

        public static string GenerateRandomStringNumber(int length)
        {
            string generatedString = new string(Enumerable.Repeat(CHARS_NUMBERS, length).Select(s => s[random.Next(s.Length)]).ToArray());


            return generatedString;
        }

        public static DateTime GenerateRandomDateTime(int startYear, int endYear)
        {
            int year = random.Next(startYear, endYear);
            int month = random.Next(1, 12);
            int day = random.Next(1, 28);

            return new DateTime(year, month, day);
        }

        public static int GenerateRandomInt(int max)
        {
            return random.Next(max);
        }
        public static decimal GenerateRandomDecimal(int max)
        {
            return Convert.ToDecimal(random.Next(max));
        }

        public static decimal GenerateRandomDecimal(int min, int max)
        {
            return Convert.ToDecimal(random.Next(min, max));
        }
        public static int GenerateRandomInt(int min, int max)
        {
            return random.Next(min, max);
        }
    }

    public enum StringCaseStyle
    {
        TitleCase = 1,
        UpperCase = 2,
        LowerCase = 3,
        None = 4,
        EmailCase = 5
    }
}
