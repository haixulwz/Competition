using System;
using System.Collections.Generic;
using System.Text;

namespace dp.Decorator
{
   public class ConcreteDecoratorB:Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("aaaaaaaaaaaa");
        }
    }
}
