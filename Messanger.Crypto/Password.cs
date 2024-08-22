using System.Security.Cryptography;
using System.Text;

namespace Messanger.Crypto
{
    public class CryptoPassword
    {

        public string CryptoPasswords(string password)
        {
            password += "hgbuyadsfasdlf";
            var hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            var stringBuilder = new StringBuilder();

            foreach (var b in hash)
            {
                stringBuilder.Append(b.ToString("X2"));
            }

            // Создание AES сессии
            using var myAes = Aes.Create();
            myAes.Key = Convert.FromBase64String("AAECAwQFBgcICQoLDA0ODw==");
            myAes.GenerateIV(); // Генерация IV

            // Шифрование строки
            var encrypted = Cryptor.EncryptStringToBytes_Aes(stringBuilder.ToString(), myAes.Key, myAes.IV);
            var result = Convert.ToBase64String(encrypted);

            // Возвращаем зашифрованное значение
            return result;
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
