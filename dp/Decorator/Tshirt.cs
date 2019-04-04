using System;
using System.Collections.Generic;
using System.Text;

namespace dp.Decorator
{
 public   class Tshirt:Finery
    {
        public override void Show()
        {
            Console.WriteLine("穿Tshirt");
            base.Show();
        }
    }
}
