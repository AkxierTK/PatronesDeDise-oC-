using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.BuilderPattern
{
    public class BebidasAlcoholicas : IBuilder
    {
        private BebidaPreparada _preparada;

        public BebidasAlcoholicas()
        {
            Reset();
        }
        public void AddIngredientes(string ingredientes)
        {
            if (_preparada.Ingredientes == null)
                _preparada.Ingredientes = new List<string>();

            _preparada.Ingredientes.Add(ingredientes);
        }

        public void Mix()
        {
            //Esto devuelve una lista sin hacer un for i es el antecesor y j el siguiente en la lista
            string ingredientes = _preparada.Ingredientes.Aggregate((i,j) => i + ","+ j.ToString());
            _preparada.Result = ingredientes;
        }

        public void Reset()
        {
           _preparada= new BebidaPreparada();
        }

        public void Rest(int time)
        {
            Thread.Sleep(time);
            Console.WriteLine("Listo");
        }

        public void SetAlcohol(decimal alcohol)
        {
            _preparada.Alcohol = alcohol;
        }

        public void SetMilk(int milk)
        {
            _preparada.Milk = milk;
        }

        public void SetWater(int water)
        {
            _preparada.Water = water;
        }

        public BebidaPreparada  GetBebidaPreparada() => _preparada;
    }
}
