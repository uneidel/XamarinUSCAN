using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerRemote.Data
{
    public class rDocument : RealmObject,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        [ObjectId]
        [Indexed]
        public string Name { get; set; }
        public bool local { get; set; }
        public bool pdfupdated { get; set; }
        public string ContentAsText { get; set; }
        public string KeyWords { get; set; }
        public string Tags { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Synced { get; set; }
    }
}
