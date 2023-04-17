using System.Security.Cryptography;
using System.Text;

namespace ProjetoApiEntity.CrossCutting.Cryptography
{
    public class MD5Cryptography
    {
        public static string Encrypt(string value)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
            string result = string.Empty;
            foreach (var item in hash)
            {
                //X2 -> converter para string em formato Hexadecimal
                result += item.ToString("X2").ToUpper();
            }
            return result;
        }
    }
}