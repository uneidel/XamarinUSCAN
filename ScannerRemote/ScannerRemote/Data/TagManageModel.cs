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
    public class TagManageModel
    {
        private Realm _realm;

        public IEnumerable<rTag> Tags { get; private set; }

        public rTag NewEntry { get; set; }

        public ICommand AddEntryCommand { get; private set; }

        public ICommand DeleteEntryCommand { get; private set; }

        public INavigation Navigation { get; set; }

        private Transaction _transaction;

        public TagManageModel(IEnumerable<rTag> tags)
        {
            var rTags = DAL.RealmDAL.Instance;
            Tags = tags;
            _transaction = RealmDAL.Instance.BeginUpdateDocument();
            NewEntry = new rTag();
            AddEntryCommand = new Command(AddEntry);
            
        }

        private void AddEntry()
        {
            (Tags as IList<rTag>).Add(NewEntry);
            RealmDAL.Instance.AddTag(NewEntry.TagName);
        }

        

       
    }
}
