using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Infrastructure.Utility
{


    public class PasswordHasher
    {
        /// 
        /// Funkcja poniżej jest używana tylko przy tworzeniu konta. 
        /// 
        public static PasswordHashResult HashPassword(string password)
        {
            // Tworzenie soli (randomowy ciąg znaków)
            byte[] saltBytes = GenerateSalt();

            // Konwertowanie hasła na bajty
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Tworzenie obiektu SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                // Kombinowanie soli z hasłem
                byte[] saltedPasswordBytes = CombineBytes(passwordBytes, saltBytes);

                // Wyliczenie wartości skrótu hasła
                byte[] hashBytes = sha256.ComputeHash(saltedPasswordBytes);

                // Konwertowanie bajtów na ciąg znaków w formacie szesnastkowym
                string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "");

                PasswordHashResult result = new PasswordHashResult
                {
                    HashedPassword = hashedPassword,
                    Salt = Convert.ToBase64String(saltBytes)
                };

                return result;
            }
        }


        public static PasswordHashResult HashPassword(string password, string saltz)
        {
            // Tworzenie soli (randomowy ciąg znaków)
            byte[] saltBytes = Encoding.UTF8.GetBytes(saltz);

            // Konwertowanie hasła na bajty
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Tworzenie obiektu SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                // Kombinowanie soli z hasłem
                byte[] saltedPasswordBytes = CombineBytes(passwordBytes, saltBytes);

                // Wyliczenie wartości skrótu hasła
                byte[] hashBytes = sha256.ComputeHash(saltedPasswordBytes);

                // Konwertowanie bajtów na ciąg znaków w formacie szesnastkowym
                string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "");

                PasswordHashResult result = new PasswordHashResult
                {
                    HashedPassword = hashedPassword,
                    Salt = Convert.ToBase64String(saltBytes)
                };

                return result;
            }
        }

        private static byte[] GenerateSalt()
        {
            // Utworzenie losowych bajtów jako soli
            byte[] saltBytes = new byte[16];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            return saltBytes;
        }

        private static byte[] CombineBytes(byte[] array1, byte[] array2)
        {
            // Kombinowanie dwóch tablic bajtów w jedną tablicę
            byte[] combinedBytes = new byte[array1.Length + array2.Length];
            Buffer.BlockCopy(array1, 0, combinedBytes, 0, array1.Length);
            Buffer.BlockCopy(array2, 0, combinedBytes, array1.Length, array2.Length);

            return combinedBytes;
        }




    }

}
