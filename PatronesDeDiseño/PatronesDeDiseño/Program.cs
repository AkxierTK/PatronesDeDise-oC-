namespace PatronesDeDiseño
{
    class Program
    {
        static void Main(string[] args)
        {
            var singletone = Singletone.Singletone.Instance;
            var log = Singletone.Log.Instance;
            log.Save("Esto es una prueba");
            Console.WriteLine("Fin");

            var a = Singletone.Singletone.Instance;
            var b = Singletone.Singletone.Instance;

            if (a== b)
            {
                Console.WriteLine("Iguales");
            }
        }
    }
}