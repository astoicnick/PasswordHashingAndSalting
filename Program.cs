using System;

namespace saltHashFirst
{
    class Program
    {
        public Program(string blank) {}
        static void Main(string[] args)
        {
            Console.WriteLine("What size?");
            var size = long.Parse(Console.ReadLine());
            Console.WriteLine("What password?");
            var password = Console.ReadLine();
            var program = new Program("");
            var salt = program.CreateSalt(size);
            var hash = program.GenerateHash(password, salt);
            Console.WriteLine(hash);
        }
        String CreateSalt(long size)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buffer = new byte[size];
            rng.GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }
        String GenerateHash(string passwd, string salt)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(passwd + salt);
            System.Security.Cryptography.SHA256Managed sha256str = new System.Security.Cryptography.SHA256Managed();
            var hash = sha256str.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
