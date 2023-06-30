using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.DependencyInjectionPattern
{

    //La tarea de injeccion de dependencias es quitarle la responsabilidad de la creación de un objeto a otro contenga como parámetro otro objeto.
    //Dandole así el objeto ya creado para que la responsabilidad no caiga en el objeto y se pueda operar sin necesidad de conocer la función del objeto parametrizado
    //En el ejemplo se puede ver que tenemos la clase Cerveza que es también un parámetro de Bebida con cerveza
    //Por lo que si en algun momento se cambia la construcción del objeto Beer, no es responsabilidad de Bebida con cerveza como funciona
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
