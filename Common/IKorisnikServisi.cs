using Common.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using static Common.Enums;

namespace Common
{
    [ServiceContract]
    public interface IKorisnikServisi
    {
        [OperationContract]
        bool DodajKorisnika(Korisnik k);

        [OperationContract]
        bool PromeniKorisnikovaPolja(Korisnik k);

        [OperationContract]
        void ProveriKorisnika(string ime, string sifra);

        [OperationContract]
        Korisnik Get(string ime);

        //skola servisi
        [OperationContract]
        bool DodajSkolu(AutoSkola skola);

        [OperationContract]
        bool ObrisiSkolu(AutoSkola skola);

        [OperationContract]
        List<AutoSkola> ListaSvihSkola();

        [OperationContract]
        bool IzmeniSkolu(AutoSkola skola);

        //
        [OperationContract]
        bool DuplicateSchool(AutoSkola ss);

        [OperationContract]
        BindingList<AutoSkola> SveSkole();

        [OperationContract]
        bool Probaj(AutoSkola skolaa);

        //instruktori
        [OperationContract]
        bool AddInsturktor(string name, int idPL, VrstaObrazovanja oznaka, string prezime);

        [OperationContract]
        List<Instruktor> SviInstruktori(int id);
        [OperationContract]
        bool IzmeniInstruktora(Instruktor ra);

        [OperationContract]
        bool IzbrisiInstruktora(Instruktor RA);

        //dozvole
        [OperationContract]
        List<Dozvola> SveDozvole(int id);

        [OperationContract]
        bool AddDozvola(string name, int idPL, VrstaDozvole oznaka);

        [OperationContract]
        bool IzbrisiDozvolu(Dozvola RA);

        [OperationContract]
        bool IzmeniDozvolu(Dozvola ra);
    }
}
