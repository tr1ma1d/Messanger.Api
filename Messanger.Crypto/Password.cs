using System.Security.Cryptography;
using System.Text;

namespace Messanger.Crypto
{
    public class CryptoPassword
    {

        private const string Salt = "hgbuyadsfasdlf"; // Фиксированная соль

        // Метод для хеширования пароля при регистрации
        public string CryptoPasswords(string password)
        {
            password += Salt; // Добавляем соль
            var hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            var stringBuilder = new StringBuilder();

            foreach (var b in hash)
            {
                stringBuilder.Append(b.ToString("X2"));
            }

            return stringBuilder.ToString(); // Возвращаем хешированный пароль
        }

        // Метод для проверки пароля при входе
        public bool VerifyPassword(string password, string storedHash)
        {
            password += Salt; // Добавляем ту же соль
            

            var hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            var stringBuilder = new StringBuilder();

            foreach (var b in hash)
            {
                stringBuilder.Append(b.ToString("X2"));
            }

            var hashedEnteredPassword = stringBuilder.ToString();
            Console.WriteLine($"Hashed entered password: {hashedEnteredPassword}");

            return storedHash == hashedEnteredPassword; // Сравниваем хеши
        }

    }

    public static class Cryptor
    {
        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException(nameof(plainText));
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException(nameof(Key));
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException(nameof(IV));

            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }

            return encrypted;
        }
    }
}
