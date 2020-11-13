using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Logic
{
    class PassHelp
    {
        public string GeneratePass()
        {
            Random random = new Random();
            var partOne = Enumerable.Range(0, 1).Select(x => (char)random.Next('A', 'Z' + 1));
            var partTwo = Enumerable.Range(0, 4).Select(x => (char)random.Next('a', 'z' + 1));
            var partThree = Enumerable.Range(0, 3).Select(x => (char)random.Next('!', '/' + 1));
            var partFour = Enumerable.Range(0, 1).Select(x => (char)random.Next('0', '9' + 1));
            return  string.Concat(partOne.Concat(partTwo).Concat(partThree).Concat(partFour));
        }
        public string HashPassword(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }
    }
}
