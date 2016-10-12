using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerRemote.Data
{
    public class rTag : RealmObject, INotifyPropertyChanged
    {
        [ObjectId]
        [Indexed]
        public string TagName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
