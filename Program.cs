using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static System.Console;

namespace openssl_aes_128_ctr
{
    class Program
    {

        static void Main(string[] args)
        {

                string password = string.Empty;
                string IV = string.Empty;
                Chilkat.Crypt2 AES = new Chilkat.Crypt2();
                string path = @"D:\4year\cybersecurity\lab5\";// шлях до текстових файлів
                Console.WriteLine("Name of file: ");
                string text = ReadFile(path + Console.ReadLine() + ".txt");
                Console.WriteLine("password: ");
                password = Console.ReadLine();
                Console.WriteLine("IV: ");
                IV = Console.ReadLine();
                AES.CryptAlgorithm = "aes";
                AES.CipherMode = "ctr";
                AES.KeyLength = 128;
                AES.EncodingMode = "base64";
                AES.SetEncodedIV(IV, "ascii");
                AES.SetEncodedKey(password, "ascii");
                AES.HashAlgorithm = "md5";
                Console.WriteLine("Name of file to save encrypted: ");
                File.WriteAllText(path + Console.ReadLine() + ".txt", AES.EncryptStringENC(text));
                Console.WriteLine("Name of file to deencrypt: ");
                text = ReadFile(path + Console.ReadLine() + ".txt");
                Console.WriteLine("password: ");
                password = Console.ReadLine();
                Console.WriteLine("IV: ");
                IV = Console.ReadLine();
                AES.SetEncodedIV(IV, "ascii");
                AES.SetEncodedKey(password, "ascii");
                Console.WriteLine(AES.DecryptStringENC(text));
                Console.ReadKey();
        }

        static string ReadFile(string pathFile)
        {
            using (StreamReader file = new StreamReader(pathFile, Encoding.GetEncoding("UTF-8")))
            {
                string ln;
                string text = "";

                while ((ln = file.ReadLine()) != null)
                {
                    text += ln + "\n";
                }
                return text;
            }
        }


    }
}