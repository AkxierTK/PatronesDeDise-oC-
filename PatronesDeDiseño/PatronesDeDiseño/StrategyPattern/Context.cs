using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.StrategyPattern
{
    public class Context 
    {
        private IStrategy _strategy;

        public IStrategy Strategy
        {
            set { _strategy = value; }
        }

        public Context (IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void run()
        {
            _strategy.Run();
        }

    }
}
