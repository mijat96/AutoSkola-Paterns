using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class AutoSkola : INotifyPropertyChanged
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDSkole { get; set; }

        [DataMember]
        public string MBR { get; set; }

        [DataMember]
        public string naziv { get; set; }
        
        [DataMember]
        public string PIB { get; set; }

        public AutoSkola() { }
        public AutoSkola(string n)
        {
            naziv = n;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
