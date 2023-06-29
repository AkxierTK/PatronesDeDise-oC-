using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.DependencyInjectionPattern
{
    public class Beer
    {
        private string _name;
        private string _brand;

        public string brand { get; set; }
        public string name { get; set; }

        public Beer (string name, string brand)
        {
            _name = name;
            _brand = brand;
        }

    }

    public class BebidaConCerveza
    {
        private Beer _beer;
        private decimal _water;
        private decimal _sugar;

        public BebidaConCerveza (Beer beer, decimal water, decimal sugar)
        {
            _beer = beer;
            _water = water;
            _sugar = sugar;
        }

        public void Build()
        {
            Console.WriteLine($" La bebida lleva {_beer.brand}");
        }

    }


}
