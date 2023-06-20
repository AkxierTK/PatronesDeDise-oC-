namespace Tools
{
    //Al declarar el constructor privado es imposible generar un objeto de manera normal
    //La propiedad _Instance al ser statica pertenece a la clase y no al objeto por lo que siempre se devuelve la misma instancia.
    //Permite poder gestionar que solo exista un elemento ya sea por funcionalidad, una única conexión. Por ejemplo el acceso a una base de datos.
    
    //Una clase sealed no se puede heredar
    public sealed class Log
    {
        private static Log _instance = null;
        private string _path;
        private static object _protect = new object();

        //Al crear un objeto static y en el método get Instance meterlo en lock el objeto se mantendrá invariable hasta que sea liberado para poder trabajar de manera async.
        //Si se llama por primera vez a la clase lo que se hace es generar el objeto. Al ser privado y no haber un get sigue siendo inaccesible
        //por lo que no se puede acceder por propiedades solo por el método de GetInstance. A su vez para poder utilizarlo en más proyectos
        //se va a crear la propiedad path como parte del GetInstance para poder asignar según el proyecto la ruta del log
       public static Log GetInstance(string path)
        {
            lock(_protect)
            if (_instance == null)
            {
                _instance = new Log(path);
            }

            return _instance;

        }

        public void Save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }


        private Log(string path) 
        {
            _path = path;
        }
    }
}