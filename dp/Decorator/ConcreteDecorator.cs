using System;
using System.Collections.Generic;
using System.Text;

namespace dp.Decorator
{
   public class ConcreteDecorator:Decorator
    {
        private string state = "aaaa";

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine(state);
        }
    }
}
