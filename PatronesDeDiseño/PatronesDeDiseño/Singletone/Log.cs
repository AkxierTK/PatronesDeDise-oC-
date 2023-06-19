using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.Singletone
{
    //Al declarar el constructor privado es imposible generar un objeto de manera normal
    //La propiedad _Instance al ser statica pertenece a la clase y no al objeto por lo que siempre se devuelve la misma instancia.
    //Permite poder gestionar que solo exista un elemento ya sea por funcionalidad, una única conexión. Por ejemplo el acceso a una base de datos.
    public class Log
    {
        private readonly static Log _instance = new Log();
        private string _path = "log.txt";

        public static Log Instance
        {
            get 
            { 
                return _instance; 
            }
        }

        public void Save( string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }


        private Log() { }   


    }
}
