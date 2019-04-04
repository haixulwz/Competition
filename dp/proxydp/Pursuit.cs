using System;
using System.Collections.Generic;
using System.Text;

namespace dp.proxydp
{
  public  class Pursuit:IGivegift
    {
        SchoolGirl girl;
        public Pursuit(SchoolGirl girl)
        {
            this.girl = girl;
        }

        public void Give1()
        {
            Console.WriteLine("11111111");
            //throw new NotImplementedException();
        }

        public void Give2()
        {
            Console.WriteLine("2222222222");
        }

        public void Give3()
        {
            Console.WriteLine("3333333333");
        }
    }
}
