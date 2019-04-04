using System;
using System.Collections.Generic;
using System.Text;

namespace dp.simplefactory
{
   public class OperatorFactory
    {
        public static Operator Create(string op)
        {
            switch (op)
            {
                case "+":
                    return new OperatorAdd();
                case "-":
                    return new OperatorSub();
                default:
                    throw new Exception("不支持啊");
            }
        }
    }
}
