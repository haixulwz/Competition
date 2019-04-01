using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
  public  class MyProvider
    {

        ConnectionFactory factory = new ConnectionFactory {
            UserName="liwenzan",
            Password="liwenzan",
            HostName= "http://localhost:15672"
        };
        
    }
}
