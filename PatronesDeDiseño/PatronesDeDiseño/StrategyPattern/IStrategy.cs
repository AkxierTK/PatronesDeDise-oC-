using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.StrategyPattern
{
    //Permite mantener el principio abierto/cerrado sin modificar el resto, la responsibilidad del objeto la tiene el objeto que implementa strategy
    //Con esto da igual que clase lo llame podremos usar la misma función para distintos objetos de una manera abstracta
    public interface IStrategy
    {
        public void Run();
    }
}
