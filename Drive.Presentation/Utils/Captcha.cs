
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
            captcha[0] = letters[_random.Next(letters.Length)];
            captcha[1] = digits[_random.Next(digits.Length)];
            
            for (int i = 2; i < length; i++)
            {
                if (_random.Next(2) == 0)                
                    captcha[i] = letters[_random.Next(letters.Length)];
                
                else                
                    captcha[i] = digits[_random.Next(digits.Length)];                
            }
            return new string(captcha);
        }

        public static bool ValidateCaptcha(string generatedCaptcha)
        {
            while (true) 
            {
                Console.WriteLine("Please enter the CAPTCHA: ");
                var userInput = Console.ReadLine();
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
