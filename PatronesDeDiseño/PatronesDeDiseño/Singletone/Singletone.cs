using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.Singletone
{
    public class Singletone
    {

        private readonly  static Singletone _instance = new Singletone();


        public static Singletone Instance
        {
            get
            {
                return _instance;
            }

        }

        private Singletone()
        {

        }

    }
}
