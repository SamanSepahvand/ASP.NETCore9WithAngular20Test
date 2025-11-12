using System.Security.Cryptography;

namespace CoreAngular1.Infrastructure
{
    public static class StringCryptor
    {
        private static string SaltText { get { return "tu89geji340t!@#$"; } }
        public static string Encrypt(string text, string salt)
        {
            byte[] Results;
            var UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below
            var HashProvider = new MD5CryptoServiceProvider();
            var TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(salt + SaltText));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            var TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            var dataToEncrypt = UTF8.GetBytes(text);

            // Step 5. Attempt to encrypt the string
            try
            {
                var encryptor = TDESAlgorithm.CreateEncryptor();
                Results = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }

        public static string Decrypt(string text, string salt)
        {
            byte[] Results;
            var UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            var hashProvider = new MD5CryptoServiceProvider();
            var TDESKey = hashProvider.ComputeHash(UTF8.GetBytes(salt + SaltText));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            var TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            var DataToDecrypt = Convert.FromBase64String(text);

            // Step 5. Attempt to decrypt the string
            try
            {
                var Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                hashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }

    }
}
