using System;
using System.Collections.Generic;
using System.Text;

namespace dp.Decorator
{
    public class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("具体的组件");
        }
    }
}
