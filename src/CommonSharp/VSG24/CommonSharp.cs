using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace VSG24.CommonSharp
{
    /// <summary>
    /// Inlcudes only common static methods
    /// </summary>
    public class CommonSharp
    {
        // Begin: Md5

        /// <summary>
        /// Returns hashed input using MD5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string MD5(string input)
        {
            var ue = Encoding.UTF8;
            var bytes = ue.GetBytes(input);
            var md5Alg = System.Security.Cryptography.MD5.Create();
            var hash = md5Alg.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            foreach (var b in hash)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

        // End: Md5

        // Begin: SHA1

        /// <summary>
        /// Returns hashed input using SHA1
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string SHA1(string input)
        {
            var ue = Encoding.UTF8;
            var bytes = ue.GetBytes(input);
            var sha1Alg = System.Security.Cryptography.SHA1.Create();
            var hash = sha1Alg.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            foreach (var b in hash)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

        // End: SHA1

        // Begin: RemoveSpecialCharacters

        /// <summary>
        /// Removes every character from string but alphanumerics or dash or underscore if specified
        /// </summary>
        /// <param name="str"></param>
        /// <param name="includeUnderscore"></param>
        /// <param name="includeDash"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a random element of the provided array
        /// </summary>
        /// <param name="input"></param>
        /// <param name="returnIndex"></param>
        /// <returns></returns>
        public static object ArrayRand(object[] input, bool returnIndex = false)
        {
            var randObj = new Random();
            if (returnIndex)
            {
                return (int)randObj.Next(0, input.Length);
            }
            return input[randObj.Next(0, input.Length)];
        }

        /// <summary>
        /// Returns a random element of the provided array
        /// </summary>
        /// <param name="input"></param>
        /// <param name="returnIndex"></param>
        /// <returns></returns>
        public static object ArrayRand(int[] input, bool returnIndex = false)
        {
            var randObj = new Random();
            if (returnIndex)
            {
                return (int)randObj.Next(0, input.Length);
            }
            return input[randObj.Next(0, input.Length)];
        }

        /// <summary>
        /// Returns a random element of the provided array
        /// </summary>
        /// <param name="input"></param>
        /// <param name="returnIndex"></param>
        /// <returns></returns>
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
