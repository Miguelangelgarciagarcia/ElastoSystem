using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElastoSystem
{
    public static class VariablesGlobales
    {
        public static string Usuario {  get; set; }
        public static string ConexionElastoSystem = "server=10.120.1.3 ; username=root; password=; database=elastosystem";
        public static string ConexionElastotec = "server=10.120.1.3 ; username=root; password=; database=elastotec";
        public static string ConexionLocal = "server=localhost ; username=root; password=; database=elastosystem";
    }
}
