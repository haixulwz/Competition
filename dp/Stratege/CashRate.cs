using System;
using System.Collections.Generic;
using System.Text;

namespace dp.Stratege
{
    public class CashRate : CashBase
    {
        private decimal _rate;
        public CashRate( decimal rate)
        {
            _rate = rate;
        }
        public override decimal GetResult(decimal money)
        {
            return money * _rate;
            //throw new NotImplementedException();
        }
    }
}
