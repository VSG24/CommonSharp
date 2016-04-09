using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CommonSharp
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class CommonSharp
    {
        // Begin: Md5

        public static string Md5(string input)
        {
            var ue = Encoding.UTF8;
            var bytes = ue.GetBytes(input);
            var md5Alg = MD5.Create();
            var hash = md5Alg.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            foreach (var b in hash)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

        // End: Md5

        // Begin: RemoveSpecialCharacters

        public static string RemoveSpecialCharacters(string str, bool includeUnderscore = false, bool includeDash = false)
        {
            if(includeUnderscore && !includeDash)
            {
                return Regex.Replace(str, "[^a-zA-Z0-9_]+", "", RegexOptions.Compiled);
            }
            else if(includeDash && !includeUnderscore)
            {
                return Regex.Replace(str, "[^a-zA-Z0-9-]+", "", RegexOptions.Compiled);
            }
            else if(includeUnderscore && includeDash)
            {
                return Regex.Replace(str, "[^a-zA-Z0-9_-]+", "", RegexOptions.Compiled);
            }
            else
            {
                return Regex.Replace(str, "[^a-zA-Z0-9]+", "", RegexOptions.Compiled);
            }
        }

        // End: RemoveSpecialCharacters

        // Begin: ArrayRand

        public static object ArrayRand(object[] input, bool returnIndex = false)
        {
            var randObj = new Random();
            if (returnIndex)
            {
                return (int)randObj.Next(0, input.Length);
            }
            return input[randObj.Next(0, input.Length)];
        }

        public static object ArrayRand(int[] input, bool returnIndex = false)
        {
            var randObj = new Random();
            if (returnIndex)
            {
                return (int)randObj.Next(0, input.Length);
            }
            return input[randObj.Next(0, input.Length)];
        }

        public static object ArrayRand(double[] input, bool returnIndex = false)
        {
            var randObj = new Random();
            if (returnIndex)
            {
                return (int)randObj.Next(0, input.Length);
            }
            return input[randObj.Next(0, input.Length)];
        }

        // End: ArrayRand
    }
}
