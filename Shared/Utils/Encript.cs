using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Utils
{
    public static class Encript
    {
        public static string GetPasswordEncripted(string pass, string nameForSalt="qualquer coisa")
        {
            var strArr = nameForSalt.ToCharArray();

            //Pega os 3 primeiros digitos do nome pro salt
            string str = strArr[0].ToString() + strArr[1].ToString() + strArr[2].ToString();


            byte[] salt = Encoding.UTF8.GetBytes(str);


            string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
               password: pass,
               salt: salt,
               prf: KeyDerivationPrf.HMACSHA256,
               iterationCount: 10000,
               numBytesRequested: 256 / 8
            ));

            return hash;
        }
    }
}
