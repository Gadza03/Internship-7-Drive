using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Presentation.Utils
{
    public static class Captcha
    {
        public static string GenerateCaptcha(int length = 6)
        {
            var _random = new Random();
            const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";

            var captcha = new char[length];

            bool containsLetter = false;
            bool containsDigit = false;

            for (int i = 0; i < length; i++)
            {
                char selectedChar;
                if (_random.Next(2) == 0 || containsLetter && !containsDigit)
                {
                    selectedChar = letters[_random.Next(letters.Length)];
                    containsLetter = true;
                }
                else
                {
                    selectedChar = digits[_random.Next(digits.Length)];
                    containsDigit = true;
                }
                captcha[i] = selectedChar;
            }
            return new string(captcha); ;
        }

        public static bool ValidateCaptcha(string generatedCaptcha)
        {
            while (true) 
            {
                Console.WriteLine("Please enter the CAPTCHA: ");
                string userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput))
                    return false;

                if (generatedCaptcha != userInput)
                {
                    Console.WriteLine("CAPTCHA does not match. Please try again.");
                    continue;
                }
                Console.WriteLine("CAPTCHA verified successfully.");
                return true;
            }

            
        }
    }    
}
