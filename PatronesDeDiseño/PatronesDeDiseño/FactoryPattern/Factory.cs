using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.FactoryPattern
{

    //Este patron de diseño funciona de la siguiente manera se crea una clase abstracta de las que se va a heredar un metodo que devuelve una interfaz ISale
    //Seguir en ISale-->
    //Creador
    public abstract class SaleFactory
    {
        public abstract ISale GetSale();
    }

    //Creador concreto
    public class StoreSaleFactory : SaleFactory
    {

        private decimal _extra;

        public StoreSaleFactory(decimal extra)
        {
            _extra = extra;
        }

        public override ISale GetSale()
        {
            return new StoreSale(_extra);
        }
    }

    //Finalmente tenemos la Fabrica que hereda de SaleFactory la obligatoriedad de tener el metodo GetSale() que devuelve un producto que hereda de la interfaz ISale
    //Esta fabrica tiene que tenener los mismos parámetros en su constructor que el objeto que devuelve su ISale
    //Con esto obtenemos que si necesitamos cambiar en cualquier momento las propiedades de los objetos solo deberemos cambiarlo en el objeto y en la fabrica y por lo tanto no deberemos
    //restructurar todo el código
    public class OnlineSaleFactory : SaleFactory
    {

        private decimal _discount;

        public OnlineSaleFactory(decimal discount)
        {
            _discount = discount;
        }

        public override ISale GetSale()
        {
            return new OnlineSale(_discount);
        }
    }

    //Producto Concreto
    public class StoreSale : ISale
    {
        private decimal _extra;

        public StoreSale(decimal extra)
        {
            _extra = extra;
        }

        public void Sell(decimal total)
        {
            Console.WriteLine($"Venta en tienda de un total de {total + _extra}");
        }
    }

    //Se trada de los "Productos" los cuales van a implementar la interfaz y por lo tanto tendrán los metodos de la misma
    public class OnlineSale : ISale
    {
        private decimal _discount;

        public OnlineSale (decimal discount)
        {
            _discount = discount;
        }

        public void Sell(decimal total)
        {
            Console.WriteLine($"Venta en tienda de un total de {total - _discount} ");
        }
    }


    //Producto
    //Interfaz en la que se van a enfocar los productos con sus valores generales
    public interface ISale
    {
        public void Sell(Decimal total);
    }
}
