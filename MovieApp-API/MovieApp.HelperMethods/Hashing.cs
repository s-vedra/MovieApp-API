using System.Security.Cryptography;
using System.Text;

namespace MovieApp.HelperMethods
{
    public class Hashing : IHasher
    {
        public string Hash(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Encoding.ASCII.GetString(md5Data);
        }
    }
}