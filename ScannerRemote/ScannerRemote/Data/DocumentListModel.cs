using System;
using System.Collections.Generic;
using System.Windows.Input;
using Realms;
using Xamarin.Forms;
using ScannerRemote.DAL;
using ScannerRemote.Pages;


namespace ScannerRemote.Data
{

    public class DocumentListModel
    {
        private Realm _realm;

        public IEnumerable<rDocument> Entries { get; private set; }

        public ICommand AddEntryCommand { get; private set; }

        public ICommand DeleteEntryCommand { get; private set; }

        public INavigation Navigation { get; set; }

        public DocumentListModel()
        {
            _realm = Realm.GetInstance();
            var rDAL = DAL.RealmDAL.Instance;

            Entries = rDAL.GetAllDocuments();

            AddEntryCommand = new Command(AddEntry);
            //DeleteEntryCommand = new Command<rDocument>(DeleteEntry);
        }

        private void AddEntry()
        {
            var transaction = _realm.BeginWrite();
            var entry = _realm.CreateObject<rDocument>();
           
        }

        internal void EditEntry(rDocument rDocument)
        {
            var page = new TabbedDocumentViewPage(new DocumentDetailModel(rDocument, Navigation));          
            Navigation.PushAsync(page);
        }

        /*private void DeleteEntry(JournalEntry entry)
        {
            _realm.Write(() => _realm.Remove(entry));
        }
        */
    }
}
