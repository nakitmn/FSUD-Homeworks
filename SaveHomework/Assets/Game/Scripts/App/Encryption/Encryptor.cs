using Modules.Ecryption;

namespace SampleGame.App
{
    public static class Encryptor
    {
        private static readonly string _password = "123";
        private static readonly byte[] _salt = {0x52, 0x41, 0x16, 0x79, 0x86, 0x64, 0x97, 0x22};
        
        public static string Encrypt(string input)
        {
            return AesEncryptor.Encrypt(input, _password, _salt);
        }
        
        public static string Decrypt(string input)
        {
            return AesEncryptor.Decrypt(input, _password, _salt);
        }
    }
}