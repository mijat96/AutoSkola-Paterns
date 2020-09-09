using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static Common.Enums;

namespace Common
{
    [DataContract]
    public class Instruktor : INotifyPropertyChanged
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDInstruktor { get; set; }

        [DataMember]
        public string ime { get; set; }

        [DataMember]
        public VrstaObrazovanja obrazovanje { get; set; }

        [DataMember]
        public string prezime { get; set; }

        [DataMember]
        public int IDSK { get; set; }
        public Instruktor() { }
        public Instruktor(string ime, int IDSk, VrstaObrazovanja o, string prezime)
        {
            this.ime = ime;
            this.obrazovanje = o;
            this.prezime = prezime;
            this.IDSK = IDSk;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
