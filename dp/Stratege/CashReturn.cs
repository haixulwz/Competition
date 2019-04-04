using System;
using System.Collections.Generic;
using System.Text;

namespace dp.Stratege
{
    public class CashReturn : CashBase
    {
        private decimal intomoney;
       
        public CashReturn(decimal i)
        {
            intomoney = i;
           
        }
        public override decimal GetResult(decimal money)
        {
            if (money > 100)
            {
                return money - intomoney;
            }
            return intomoney;
           // throw new NotImplementedException();
        }
    }
}
