using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
namespace Base64EncodeFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start");

            string path = @"mimikatz.exe";
            try
            {

                byte[] readText = File.ReadAllBytes(path);
                foreach (byte s in readText)
                {
                    var d = (char)s;
                    Console.Write(convertBase64(d.ToString()));
                    insertByteInBase64(convertBase64(d.ToString()));
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro ao ler o arquivo: " + e.Message);
            }
            Console.ReadKey();
        }

        static string convertBase64(string texto)
        {
            try
            {
                byte[] textoAsBytes = Encoding.ASCII.GetBytes(texto);
                string resultado = System.Convert.ToBase64String(textoAsBytes);
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }
        static void insertByteInBase64(string byteEncoded)
        {
            StreamWriter file = new StreamWriter("encripted.exe");
            file.Write(byteEncoded);
            file.Close();
        }
    }
}
