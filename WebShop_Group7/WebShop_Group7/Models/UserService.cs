using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebShop_Group7.Models
{
    public class UserService
    {
        public string CreateSalt(int size) //Metod för att skapa salt, tar en inparameter som bestämmer längden på saltet.
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider(); //Skapar upp en ny "Random generator" från security namespase.
            var buff = new byte[size]; //Skapar upp en array med längden från inparametern.
            rng.GetBytes(buff); //Random genererar bytes i arrayen
            return Convert.ToBase64String(buff); //Konverterar och returnerar det nu färdiga saltet.
        }

        public string GenerateSHA256Hash(string input, string salt) //Metod för att hasha lösenordet tillsammans med ett salt
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt); //Kodar om input tillsammans med saltet och lägger i en byte array
            var sha256hashstring = new System.Security.Cryptography.SHA256Managed(); //Skapar upp en SHA256 krypterare från namespacet security
            byte[] hash = sha256hashstring.ComputeHash(bytes); //Skickar in vår byte variabel till vår SHA256 krypterare och tilldear hashen till en variabel

            return Convert.ToBase64String(hash); //Konverterar hashen till en string och returnerar.
        }

       
    }
}