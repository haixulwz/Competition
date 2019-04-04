using System;
using System.Collections.Generic;
using System.Text;

namespace dp.Decorator
{
  public  class Kuzi:Finery
    {
        public override void Show()
        {
            Console.WriteLine("穿裤子");
            base.Show();
        }
    }
}
