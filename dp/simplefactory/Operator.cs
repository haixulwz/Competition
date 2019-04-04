using System;
using System.Collections.Generic;
using System.Text;

namespace dp.simplefactory
{
  public abstract class Operator
    {
        public decimal NumberA { get; set; } 
        public decimal NumberB { get; set; } 
        public virtual decimal GetResult() {
            return 0;
        }
    }

    public class OperatorAdd : Operator
    {
        public override decimal GetResult()
        {
            return NumberA + NumberB;
        }
    }
    public class OperatorSub : Operator
    {
        public override decimal GetResult()
        {
            return NumberA-NumberB;    
        }
    }
}
