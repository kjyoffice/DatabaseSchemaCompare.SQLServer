using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace DatabaseSchemaCompare.SQLServer.XValue
{
    public class ProcessValue
    {
        public static string ReportDirectoryPath(string dirPath)
        {
            var result = (
                (dirPath == string.Empty) ?
                Path.Combine(Environment.CurrentDirectory, "Report") :
                Path.GetFullPath(dirPath)
            );

            if (Directory.Exists(result) == false)
            {
                Directory.CreateDirectory(result);
            }

            return result;
        }

        public static string CreateDirectoryPath(string baseDirPath, List<string> subDirNameList)
        {
            subDirNameList.Insert(0, baseDirPath);

            var result = Path.Combine(subDirNameList.ToArray());

            if (Directory.Exists(result) == false)
            {
                Directory.CreateDirectory(result);
            }

            return result;
        }

        public static string SHA512Hash(params object[] source)
        {
            var result = string.Empty;

            using (var hash = SHA512.Create())
            {
                var buffer = Encoding.UTF8.GetBytes(
                    string.Join(string.Empty, source.Select(x => x.ToString()))
                );
                var hashing = BitConverter.ToString(hash.ComputeHash(buffer));
                result = Regex.Replace(hashing, "[^0-9A-Za-z]", string.Empty, RegexOptions.IgnoreCase).Trim().ToLower();
                hash.Clear();
            }

            return result;
        }
    }
}
