using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WebApplication1.Models
{
    public class Hash
    {
        
        public bool very(string password, string savedPasswordHash)
        {
            /* Fetch the stored value */
            //string savedPasswordHash = "1/qj1n8RUg0pVJILSey5MYomfG12uIcn";
            //string password = "AteraDevProject";
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[8];
            Array.Copy(hashBytes, 0, salt, 0, 8);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 150);
            byte[] hash = pbkdf2.GetBytes(16);
            /* Compare the results */
            for (int i = 0; i < 16; i++)
                if (hashBytes[i + 8] != hash[i])
                    throw new UnauthorizedAccessException();

            return true;
        }
    }
}
