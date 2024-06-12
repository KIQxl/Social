using Flunt.Validations;
using Social.Shared.ValueObjects;
using System.Security.Cryptography;
using System.Text;

namespace Social.Domain.ValueObjects
{
    public class Password : ValueObject
    {
        private const string Valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
        private const string Special = @"!@#$%^&*()_-+={[}]|\~?';.,<>/";

        public Password(string password)
        {
            AddNotifications( new Contract()
                .Requires()
                .IsNotNullOrEmpty(password, "password", "A senha é obrigatória")
                .HasMinLen(password, 8, "Password", "A senha deve conter no mínimo 8 caractéres")
                );

            PasswordSalt = GenerateSalt();
            PasswordHash = HashPassword(password);
        }

        public string PasswordHash { get; private set; }
        public string PasswordSalt { get; private set;}

        private string HashPassword(string password)
        {
            string passwordWithSalt = password + this.PasswordSalt;

            using (var sha256 = SHA256.Create())
            {
                // convertendo o resultado da concatenação para um array de bytes
                byte[] bytes = Encoding.UTF8.GetBytes(passwordWithSalt);

                // criando o hash
                byte[] hash = sha256.ComputeHash(bytes);

                // convertendo o hash para uma string base 64 e retornando a mesma
                return Convert.ToBase64String(hash);
            }
        }

        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public static string GenerateRandomPassword(short length = 16, bool includeSpecial = true)
        {
            var chars = includeSpecial ? (Valid + Special) : Valid;
            var index = 0;
            Random random = new Random();

            string password = new string(
                new[]
                 {
                    chars[random.Next(Valid.Length)]
                 }
             .Concat(Enumerable.Repeat(chars, length)
                 .Select(s => s[random.Next(s.Length)]))
             .ToArray());

            password = new string(password.ToCharArray().OrderBy(c => random.Next()).ToArray());

            return password;
        }

        public bool Challenge(string password)
        {
            return this.PasswordHash == HashPassword(password);
        }
    }
}
