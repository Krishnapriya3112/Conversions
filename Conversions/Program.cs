using Conversions.Models;
using Converter.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Conversions
{
    class Program
    {

        static void Main(string[] args)
        {

            string val;
            Console.Write("Enter a name: ");
            val = Console.ReadLine();


            BinaryConverter binaryConverter = new BinaryConverter();
            string binaryValue = binaryConverter.ConvertTo(val);
            Console.WriteLine($"{val} as Binary: {binaryValue}");
            Console.WriteLine($"{val} from Binary to ASCII: {binaryConverter.ConvertBinaryToString(binaryValue)}");

            HexadecimalConverter hexadecimalConverter = new HexadecimalConverter();
            string hexadecimalValue = hexadecimalConverter.ConvertTo(val);
            Console.WriteLine($"{val} as Hexadecimal: {hexadecimalValue}");
            Console.WriteLine($"{val} from Hexadecimal to ASCII: {hexadecimalConverter.ConveryFromHexToASCII(hexadecimalValue)}");

            int[] cipher = new[] { 1, 1, 2, 3, 5, 8, 13 }; //Fibonacci Sequence
            string cipherasString = String.Join(",", cipher.Select(x => x.ToString())); //FOr display

            int encryptionDepth = 20;

            Encrypter encrypter = new Encrypter(val, cipher, encryptionDepth);

            Console.WriteLine($"Base64 encoded {val} {encrypter.Base64}");

            string base64toPlainText = Encrypter.Base64ToString(encrypter.Base64);
            Console.WriteLine($"Base64 decoded {encrypter.Base64} {base64toPlainText}");

            //Deep Encrytion
            string nameDeepEncryptWithCipher = Encrypter.DeepEncryptWithCipher(val, cipher, encryptionDepth);
            Console.WriteLine($"Deep Encrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepEncryptWithCipher}");

            string nameDeepDecryptWithCipher = Encrypter.DeepDecryptWithCipher(nameDeepEncryptWithCipher, cipher, encryptionDepth);
            Console.WriteLine($"Deep Decrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepDecryptWithCipher}");

         
           


        }

    }

}