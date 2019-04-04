using System;
using System.Collections.Generic;
using System.Text;

namespace dp.Decorator
{
    public class Decorator : Component
    {
        protected Component component;
        public override void Operation()
        {
            if (component!=null)
            {
                component.Operation();
            }
        }
        public void SetComponent(Component c){
            component = c;
        }

    }
}
