using PatronesDeDiseño.DependencyInjectionPattern;
using PatronesDeDiseño.FactoryPattern;
using PatronesDeDiseño.Models;
using PatronesDeDiseño.RepositoryPattern;
using PatronesDeDiseño.StrategyPattern;
using PatronesDeDiseño.UnityOfWorkPattern;
using System.Linq.Expressions;
using Beer = PatronesDeDiseño.DependencyInjectionPattern.Beer;

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

            //RepositoryPattern
                //Modelado directo
            //using ( var context = new PatronesDeDiseñoContext())
            //{
            //    var lst = context.Beers.ToList();

            //    foreach ( var beer in lst)
            //    {
            //        Console.WriteLine($"{beer.Name}, {beer.Style}");
            //    }

            //}

            //using (var context = new PatronesDeDiseñoContext())
            //{
            //    var beerRepository = new BeerRepository(context);

            //    var beer = new Models.Beer();

            //    beer.Name = "corona";
            //    beer.Style = "rubia";

            //    beerRepository.Add( beer );
            //    beerRepository.Save();

            //    foreach ( var beerl in beerRepository.Get())
            //    {
            //        Console.WriteLine($"{beerl.Name}, {beerl.Style}");
            //    }

            //}

            ////TEntry permite trabajar con cualquier objeto del modelo
            ////Using libera memoria conexiones al terminar
            //using (var context = new PatronesDeDiseñoContext())
            //{
            //    var beerRepository = new Repository<Brand>(context);

            //    var brand = new Brand();

            //    brand.Name = "Jonny Walker";

            //    beerRepository.Add(brand);
            //    beerRepository.Save();  
                
            //}

            ////UnityOfWork

            //using (var context = new PatronesDeDiseñoContext())
            //{
            //    var unity = new UnitOfWork(context);

            //    var beers = unity.Beers;
            //    var beers2 = unity.Beers;


            //    if (beers2 == beers)
            //    {
            //        Console.WriteLine("Iguales");
            //    }
            //    var beer  = new Models.Beer()
            //    {
            //        Name = "fuller",
            //        Style = "manuel"
            //    };

            //    var brands = unity.Brands;
            //    var brand = new Brand()
            //    {
            //        Name = "ManuelSA"
            //    };

            //    brands.Add(brand);

            //    unity.save();


            //    if (beers2== beers )
            //    {
            //        Console.WriteLine("Iguales");
            //    }

            //}

            //Strategy

            var contextS = new Context( new CarStrategy());

            contextS.run();

            contextS.Strategy= new MotoStrategy();

            contextS.run();


        }
    }
}