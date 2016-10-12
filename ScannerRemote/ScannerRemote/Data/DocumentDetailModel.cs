
using Realms;
using ScannerRemote.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScannerRemote.Data
{
    public class DocumentDetailModel 
    {
        
        public rDocument Entry { get;  set; }

        public IEnumerable<rTag> Tags { get; set; }
        internal INavigation Navigation { get; set; }

        public ICommand SaveCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }
        public ICommand AddNewTagCommand { get; private set; }
        public DocumentDetailModel(rDocument entry, INavigation navigation)
        {
            Navigation = navigation;
            Entry = entry;
            
            SaveCommand = new Command(Save);
            CancelCommand = new Command(Cancel);
            var rTags = DAL.RealmDAL.Instance;

            Tags = rTags.GetAllTags();
        }

        private void Save()
        {
           
            //Navigation.PopAsync(true);
        }

        private void Cancel()
        {
            RealmDAL.Instance.CancelUpdateDocument();
        }
        
        
    }

}

