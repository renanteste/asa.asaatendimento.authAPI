using System;
using System.Security.Cryptography;

namespace asa.asaatendimento.authAPI.Services
{
    public static class ChaveService
    {
        public static string GerarChaveJwt()
        {
            byte[] key = new byte[32]; // 256 bits
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return Convert.ToBase64String(key);
        }
    }
}
