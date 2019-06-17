using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Helpers
{
    public static class SoporteParaConfiguracion
    {
        static void Main(string[] args)
        {
        }

        public static void CrearArchivoDeConfiguracion()
        {
            string archivo = @"C:\Users\Alumno\Desktop\SolucionTPN°9\TP9 Helpers\bin\Debug\configuracion.dat";
            using (BinaryWriter writer = new BinaryWriter(File.Open(archivo, FileMode.Create)))
            {
                writer.Write(1.250F);
                writer.Write(@"c:\Temp");
                writer.Write(10);
                writer.Write(true);
            }
        }

        public static byte[] LectorCompletoDeBinario(Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream()) // creando un memory stream 
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length); // lee desde la última posición hasta el tamaño del buffer
                    if (read <= 0)
                        return ms.ToArray(); // convierte el stream en array 
                    ms.Write(buffer, 0, read); // graba en el stream 
                }
            }
        }
    }

    public static class ConversorDeMorse
    {
        public static string MorseATexto(string mensaje)
        {
            string letras = "abcdefghijklmnopqrstuvwxyz 0123456789.,?!()[]&:;=+-_$@";
            string[] codigo = new string[60];
            string morse = " ";

            codigo[0] = ".-"; //a
            codigo[1] = "-...";//b
            codigo[2] = "-.-.";//c
            codigo[3] = "-..";//d
            codigo[4] = ".";//e
            codigo[5] = "..-.";//f
            codigo[6] = "--.";//g
            codigo[7] = "....";//h
            codigo[8] = "..";//i
            codigo[9] = ".---";//j
            codigo[10] = "-.-";//k
            codigo[11] = ".-..";//l
            codigo[12] = "--";//m
            codigo[13] = "-.";//n
            codigo[14] = "---";//o
            codigo[15] = ".--.";//p
            codigo[16] = "--.-";//q
            codigo[17] = ".-.";//r
            codigo[18] = "...";//s
            codigo[19] = "-";//t
            codigo[20] = "..-";//u
            codigo[21] = "...-";//v
            codigo[22] = ".--";//w
            codigo[23] = "-..-";//x
            codigo[24] = "-.--";//y
            codigo[25] = "--..";//z
            codigo[26] = "/";//espacio
            codigo[27] = "-----";//0
            codigo[28] = ".----";//1
            codigo[29] = "..---";//2
            codigo[30] = "...--";//3
            codigo[31] = "....-";//4
            codigo[32] = ".....";//5
            codigo[33] = "-....";//6
            codigo[34] = "--...";//7
            codigo[35] = "---..";//8
            codigo[36] = "----.";//9
            codigo[37] = ".-.-.-";//.
            codigo[38] = "--..--";//,
            codigo[39] = "..--..";//?
            codigo[40] = ".-.-..";//!
            codigo[41] = "-.--.";//(
            codigo[42] = "-.--.-";//)
            codigo[43] = "-.--.";//[
            codigo[44] = "-.--.-";//]
            codigo[45] = ".-...";//&
            codigo[46] = "---...";//:
            codigo[47] = "-.-.-.";//;
            codigo[48] = "-...-";//=
            codigo[49] = ".-.-.";//+
            codigo[50] = "-....-";//-
            codigo[51] = "..--.-";//_
            codigo[52] = "...-..-";//$
            codigo[53] = ".--.-.";//@

            string[] oracion = mensaje.Split(' ');
            int max = oracion.Length;

            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < 60; j++)
                    if (oracion[i].Equals(codigo[j]))
                    {
                        morse = morse + letras[j];
                        break;
                    }
            }
            return morse;
        }

        public static string TextoAMorse(string cadena)
        {
            char[] letras = { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            string[] letrasenmorse = { "/", ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "---.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----.", "-----" };
            string Traducido = "";
            cadena = cadena.ToLower();
            for (int i = 0; i < cadena.Length; i++)
            {
                for (short j = 0; j < 37; j++)
                {
                    if (cadena[i] == letras[j])
                    {
                        Traducido += letrasenmorse[j];
                        Traducido += " ";
                        break;
                    }
                }
            }
            return Traducido;
        }

        public static void ConvertirMorse(string RutaDeArchivoMorse)
        {
            string RutaDeArchivoP = @"C:\Users\Alumno\Desktop\SolucionTPN°9\TP9 Helpers\bin\Debug\punto.mp3";
            byte[] Punto = File.ReadAllBytes(RutaDeArchivoP);
            string RutaDeArchivoR = @"C:\Users\Alumno\Desktop\SolucionTPN°9\TP9 Helpers\bin\Debug\raya.mp3";
            byte[] Raya = File.ReadAllBytes(RutaDeArchivoR);

            StreamReader Archivo = new StreamReader(RutaDeArchivoMorse);
            string RutaNuevoArchivo = @"C:\Users\Alumno\Desktop\SolucionTPN°9\TP9 Helpers\bin\Debug\Morse\MensajeMorse.mp3";

            FileStream PuntoMorse = new FileStream(RutaDeArchivoP, FileMode.Open);
            FileStream RayaMorse = new FileStream(RutaDeArchivoR, FileMode.Open);
            FileStream Mensaje = new FileStream(RutaNuevoArchivo, FileMode.Create);
        }
    }
}
