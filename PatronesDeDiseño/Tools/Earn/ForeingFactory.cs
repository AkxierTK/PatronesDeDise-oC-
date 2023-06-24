using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Earn
{
    public class ForeingFactory : EarnFactory
    {
        private decimal _percentage;
        private decimal _extra;

        public ForeingFactory (decimal percentage, decimal extra)
        {
            _percentage = percentage;
            _extra = extra;
        }

        public override IEarn GetEarn()
        {
            return new ForeingEarn(_percentage, _extra);
        }
    }
}
