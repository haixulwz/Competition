using System;
using System.Collections.Generic;
using System.Text;

namespace dp.Stratege
{
  public  class CashContext
    {
        private CashBase cashBase;
        public CashContext(string cbType,decimal para)
        {
            //  cashBase = cb;
            switch (cbType)
            {
                case "1":
                    cashBase = new CashRate(para);
                    break;
                case "2":
                    cashBase = new CashReturn(para);
                    break;
                default:
                    break;
            }
        }
        public decimal Getresult(decimal money)
        {
            return cashBase.GetResult(money);
        }
    }
}
