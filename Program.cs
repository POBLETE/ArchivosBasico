using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.IO.Compression.FileSystem;


namespace ComprimierArchivos
{
    public class Program
    {
        private static Entidad.ListFiles ListFiles = new Entidad.ListFiles();
 

        private static string path = @"C:\Users\cpoblete\Downloads\ComprimierArchivos\archivos";
        private static string directoryPath = @"C:\Users\cpoblete\Downloads\ComprimierArchivos\archivos";

     public static void comprimirListaDeArchivos (Entidad.ListFiles ListFiles)
        {

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach ( var fileToCompress in ListFiles.nombreArchivo )
                    {
                        var archivoFisico = fileToCompress.Key;
                        FileInfo directorySelected = new FileInfo(archivoFisico);
                       
                       var fileNameToAdd = Path.Combine(ListFiles.Directorio, archivoFisico);
                        archive.CreateEntryFromFile(fileNameToAdd, Path.GetFileName(fileNameToAdd));
                    }
                }


                //esto es para test developer en repo local
                using (var fileStream = new FileStream(ListFiles.NombreZip, FileMode.Create))
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    //memoryStream.CopyTo(fileStream);
                    byte[] byteZip = StreamFile(fileStream);
                }


               

                memoryStream.Dispose();
            }
        }

        static void Main(string[] args)
        {
         
         DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);
            var outFileName = Path.GetFileNameWithoutExtension("originalFileStream.Names") + ".zip";
            var zipFileName = Path.Combine(path, outFileName);


            ListFiles.Directorio = path;
            ListFiles.NombreZip = zipFileName;

      
            foreach (FileInfo fileToCompress in directorySelected.GetFiles())
            {
                var fileNameToAdd = Path.Combine(path, fileToCompress.Name);
                ListFiles.nombreArchivo.Add(Path.GetFileName(fileNameToAdd), Path.GetFileName(fileToCompress.Name));
            }

            comprimirListaDeArchivos(ListFiles);

                        

        }

        public static byte[] StreamFile(FileStream fs)
        {
            //FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

            // Create a byte array of file stream length
            byte[] ImageData = new byte[fs.Length];

            //Read block of bytes from stream into the byte array
            fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

            //Close the File Stream
            fs.Close();
            return ImageData; //return the byte data
        }


 
    }
}
