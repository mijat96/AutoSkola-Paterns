using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Konekcija
    {
        private static ServiceHost serviceHost;

        public Konekcija()
        {
            serviceHost = new ServiceHost(typeof(KorisnikServisi));
            serviceHost.AddServiceEndpoint(typeof(IKorisnikServisi), new NetTcpBinding(), new Uri("net.tcp://localhost:5000/IKorisnikServisi"));
        }

        public void Otvori()
        {
            Console.WriteLine("Servis Host je otvoren " + DateTime.Now);
            serviceHost.Open();

        }

        public void Zatvori()
        {
            Console.WriteLine("Servis Host je zatvoren " + DateTime.Now);
            serviceHost.Close();
        }
    }
}
