using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;

namespace ServicioServiceBus
{
    class Program
    {
        static void Main(string[] args)
        {
            var host=new ServiceHost(typeof(ServicioSaludo));
            host.AddServiceEndpoint(typeof (IServicioSaludo), new NetTcpBinding(), "net.tcp://localhost:6985/saludo");

            host.AddServiceEndpoint(typeof (IServicioSaludo), new NetTcpRelayBinding(),
                ServiceBusEnvironment.CreateServiceUri("sb", "demo48707", "saludo")).Behaviors.Add(new TransportClientEndpointBehavior()
                {
                    TokenProvider = TokenProvider.CreateSharedSecretTokenProvider("owner",
                    "gNZ5qIyZ7cZilcfAhnDrLmGYXJ0j9Xm66FXkV8ZM/KQ=")
                });
            host.Open();
            Console.WriteLine("Terminar....");
            Console.ReadLine();

            host.Close();

        }
    }
}
