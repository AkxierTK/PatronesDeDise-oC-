using PatronesDeDiseño.DependencyInjectionPattern;
using PatronesDeDiseño.FactoryPattern;
using System.Linq.Expressions;

namespace PatronesDeDiseño
{
    class Program
    {
        static void Main(string[] args)
        {
            //Singletone
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


            //FactoryPattern
            SaleFactory StoreSaleFactory = new StoreSaleFactory(10);
            SaleFactory OnlieSaleFactory = new OnlineSaleFactory(2);

            ISale sale1 = StoreSaleFactory.GetSale();
            ISale sale2 = OnlieSaleFactory.GetSale();

            sale1.Sell(20);

            sale2.Sell(20);


            //DependencyInjection

            Beer cerveza = new Beer("Ceveza","Aguila");

            BebidaConCerveza bebida = new BebidaConCerveza(cerveza, 10, 1);

            bebida.Build();

        }
    }
}