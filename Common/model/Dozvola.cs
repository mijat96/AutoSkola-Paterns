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
    public class Dozvola : INotifyPropertyChanged
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDDozvole { get; set; }

        [DataMember]
        public string nazivDozvole { get; set; }

        [DataMember]
        public VrstaDozvole vrstaDozvole { get; set; }

        [DataMember]
        public char[] oznakaDozvole { get; set; }

        [DataMember]
        public int IDSkole { get; set; }

        public Dozvola() { }
        public Dozvola(string ime, int IDSk, VrstaDozvole o)
        {
            this.nazivDozvole = ime;
            this.vrstaDozvole = o;
            this.IDSkole = IDSk;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
