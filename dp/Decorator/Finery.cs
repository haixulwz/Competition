using System;
using System.Collections.Generic;
using System.Text;

namespace dp.Decorator
{
  public  class Finery:Person
    {
        protected Person p;
        public void SetPerson(Person p)
        {
            this.p = p;
        }
        public override void Show()
        {
            if (p!=null)
            {
                p.Show();
            }
        }
    }
}
