using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static Common.Enums;

namespace Common.model
{
    [DataContract]
    public class Korisnik
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdKorisnika { get; set; }

        [DataMember]
        [Key]
        public string KorisnickoIme { get; set; }

        [DataMember]
        public string Sifra { get; set; }

        [DataMember]
        public Clanovi VrstaClanstva { get; set; }

        public Korisnik() { }
        public Korisnik(string Ime, string Sifra)
        {
            this.KorisnickoIme = Ime;
            this.Sifra = Sifra;
        }

    }
}
