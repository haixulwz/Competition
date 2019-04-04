using dp.Decorator;
using dp.proxydp;
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

            #region MyRegion
            //var op = new CashContext("1", 0.8M);
            //var gm = op.Getresult(100);
            //Console.Write(gm); 
            #endregion

            #region MyRegion
            //ConcreteComponent c = new ConcreteComponent();
            //ConcreteDecorator a = new ConcreteDecorator();
            //ConcreteDecoratorB b = new ConcreteDecoratorB();
            //a.SetComponent(c);
            //b.SetComponent(a);
            //b.Operation();


            //Person person = new Person("小菜");
            //Kuzi kuzi = new Kuzi();
            //Tshirt tshirt = new Tshirt();
            //kuzi.SetPerson(person);
            //tshirt.SetPerson(kuzi);
            //tshirt.Show(); 
            #endregion
            SchoolGirl g = new SchoolGirl("jjjj");
            //Pursuit p = new Pursuit(g);
            proxydp.Proxy px = new proxydp.Proxy(p);
            px.Give1();
            px.Give2();
            Console.ReadLine();
        }
    }
}
