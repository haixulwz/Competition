using System;
using System.Collections.Generic;
using System.Text;

namespace dp.proxydp
{
    public class Proxy : IGivegift
    {
        Pursuit pursuit;
        public Proxy(SchoolGirl g)
        {
            this.pursuit = new Pursuit(g);
        }
        public void Give1()
        {
            pursuit.Give1();
        }

        public void Give2()
        {
            pursuit.Give2();
        }

        public void Give3()
        {
            pursuit.Give3();
        }
    }
}
