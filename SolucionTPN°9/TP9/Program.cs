using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Helpers;

namespace TP9
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = @"C:\Users\Usuario\Desktop\SolucionTPN°9\TP9 Helpers\bin\Debug";
            string nuevaruta = @"C:\Users\Usuario\Desktop\SolucionTPN°9\TP9 Helpers\bin\Debug\Copia";
            string[] directorio = Directory.GetFiles(ruta);
            foreach (string archivo in directorio)
            {
                if (Path.GetExtension(archivo) == ".mp3" || Path.GetExtension(archivo) == ".txt")
                {
                    string nombre = Path.Combine(ruta, Path.GetFileName(archivo));
                    string rutanueva= Path.Combine(nuevaruta, Path.GetFileName(archivo));
                    if(File.Exists(rutanueva))
                    {
                        Console.Write("El archivo ya existe dentro de la carpeta.");
                        Console.WriteLine(Path.GetFileName(archivo));
                    }

                    else
                    {
                        File.Copy(nombre, rutanueva);
                    }
                }
            }
            Console.Write("Ingrese el texto a convertir a morse:");
            string texto = Console.ReadLine();

            string traduccion = ConversorDeMorse.TextoAMorse(texto);
            string rutadearchivo = @"C:\Users\Usuario\Desktop\SolucionTPN°9\TP9 Helpers\bin\Debug\Morse\Morse.txt";
            File.WriteAllText(rutadearchivo, traduccion);

            string morse = File.ReadAllText(rutadearchivo);
            string morsetrad = ConversorDeMorse.MorseATexto(morse);
            string rutaparatexto = @"C:\Users\Usuario\Desktop\SolucionTPN°9\TP9 Helpers\bin\Debug\Texto\Texto.txt";
            File.WriteAllText(rutaparatexto, morsetrad);
        }
    }
}
