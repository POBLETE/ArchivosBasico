using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComprimierArchivos.Entidad
{
    public class ListFiles
    {
        public string NombreZip { get; set; }
        public string Directorio { get; set; }
        public  Dictionary<string, string> nombreArchivo { get; set; }

        public ListFiles()
        {
            NombreZip = string.Empty;
            Directorio = string.Empty;
            this.nombreArchivo = new   Dictionary<string, string>();
        }
    }
}
 
