using dp.simplefactory;
using dp.Stratege;
using System;

namespace dp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            #region 1
            //var op = OperatorFactory.Create("+");
            //op.NumberA = 1;
            //op.NumberB = 3;
            //Console.Write(op.GetResult()); 
            #endregion

            var op = new CashContext("1", 0.8M);
            var gm=op.Getresult(100);
            Console.Write(gm);
            Console.ReadLine();
        }
    }
}
