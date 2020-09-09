using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Konekcija
    {
        public IKorisnikServisi korisnikServisi;
        private static Konekcija instance;

        public Konekcija()
        {
            ChannelFactory<IKorisnikServisi> channelKorisnik = new ChannelFactory<IKorisnikServisi>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:5000/IKorisnikServisi"));
            korisnikServisi = channelKorisnik.CreateChannel();
        }

        public static Konekcija Instance
        {

            get
            {
                if (instance == null)
                    instance = new Konekcija();
                return instance;
            }

        }
    }
}
