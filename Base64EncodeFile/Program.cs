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
            Console.ReadKey();
            string path = @"mimikatz.exe";
            try
            {
                StreamWriter file = new StreamWriter("encripted.exe");

                byte[] readText = File.ReadAllBytes(path);
                foreach (byte s in readText)
                {
                    var d = (char)s;
                    Console.Write(convertBase64(d.ToString()));
                    file.WriteLine(convertBase64(d.ToString()));
                }
                file.Close();
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
    }
}
