using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.BuilderPattern
{

    //Se utiliza para objetos y clases que tienen muchas maneras de hacerse y se necesita tener en cuenta todas las posibles maneras
    //Seria como hacer una receta de como hacer el objeto que el director es el que se encarga de establecer el orden
    public class BebidaPreparada
    {
        public List<string> Ingredientes = new List<string>();
        public int Milk;
        public int Water;
        public decimal Alcohol;


        public string Result;

    }
}
