using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.BuilderPattern
{
    public class BarmanDirector
    {
        private IBuilder _builder;

        public BarmanDirector(IBuilder builder)
        {
            _builder = builder;
        }

        public void SetBuilder(IBuilder builder)
        {
            _builder = builder;
        }

        public void PrepararMojito()
        {
            
            _builder.AddIngredientes("Ron");
            _builder.AddIngredientes("Azucar moreno");
            _builder.AddIngredientes("Lima");
            _builder.AddIngredientes("Sprite Blanco");
            _builder.SetMilk(20);
            _builder.Mix();
        }


    }
}
