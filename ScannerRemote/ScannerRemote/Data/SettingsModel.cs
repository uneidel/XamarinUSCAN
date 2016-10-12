using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScannerRemote.Helpers
{
    public class SettingsModel : INotifyPropertyChanged
    {

        public string ServerAddress
        {
            get { return Settings.ServerAddress; }
            set
            {
                if (Settings.ServerAddress == value)
                    return;

                Settings.ServerAddress = value;
                OnPropertyChanged();
            }

        }
        public int ServerPort
        {
            get { return Settings.ServerPort; }
            set
            {
                if (Settings.ServerPort == value)
                    return;

                Settings.ServerPort = value;
                OnPropertyChanged();
            }

        }
        public bool Merge
        {
            get { return Settings.Merge; }
            set
            {
                if (Settings.Merge == value)
                    return;

                Settings.Merge = value;
                OnPropertyChanged();
            }
        }
        public bool PreProcess
        {
            get { return Settings.PreProcess; }
            set
            {
                if (Settings.PreProcess == value)
                    return;

                Settings.PreProcess = value;
                OnPropertyChanged();
            }
        }

        public bool FILTERNONTAGGED
        {
            get
            {
                return Settings.FilteronNonTagged; }
            set
            {
                if (Settings.FilteronNonTagged == value)
                    return;

                Settings.FilteronNonTagged = value;
                OnPropertyChanged();
            }
        }
        public bool CreatePDFFromPIC
        {
            get { return Settings.CreatePDF; }
            set
            {
                if (Settings.CreatePDF == value)
                    return;

                Settings.CreatePDF = value;
                OnPropertyChanged();
            }
        }
        public int Resolution
        {
            get { return Settings.Resolution; }
            set
            {
                if (Settings.Resolution == value)
                    return;

                Settings.Resolution = value;
                OnPropertyChanged();
            }
        }
        public string CreatePDFFROMPIC
        {
            get { return Settings.Format; }
            set
            {
                if (Settings.Format == value)
                    return;

                Settings.Format = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed(this, new PropertyChangedEventArgs(name));
        }

        #endregion


    }
}
