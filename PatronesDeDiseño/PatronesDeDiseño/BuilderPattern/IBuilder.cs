using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.BuilderPattern
{

    //Se utiliza para objetos y clases que tienen muchas maneras de hacerse y se necesita tener en cuenta todas las posibles maneras
    //Seria como hacer una receta de como hacer el objeto que el director es el que se encarga de establecer el orden
    public interface IBuilder
    {

        public void Reset();

        public void SetAlcohol(decimal alcohol);

        public void SetWater(int water);

        public void SetMilk(int milk);

        public void AddIngredientes(string ingredientes);

        public void Mix();

        public void Rest(int time);


    }
}
