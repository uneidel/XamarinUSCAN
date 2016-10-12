using Realms;
using ScannerRemote.Data;
using ScannerRemote.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerRemote.DAL
{
    internal class RealmDAL
    {
        private Realm _realm;
        private static RealmDAL _realmDal;
        public static RealmDAL Instance
        {
            get
            {
                if (_realmDal == null)
                    _realmDal = new RealmDAL();

                return _realmDal;

            }

        }
        private RealmDAL()
        {
            _realm = Realm.GetInstance();
        }
        internal IEnumerable<rTag> GetAllTags()
        {
            List<rTag> tags = new List<rTag>();
            if (String.IsNullOrEmpty(Settings.KeyWords))
                return tags;
            foreach(var s in Settings.KeyWords.Split(';'))
            {
                tags.Add(new rTag() { TagName = s });
            }
            return tags;
        }
        internal rTag GetTag(string name)
        {

            List<rTag> tags = (List<rTag>)GetAllTags();
            return tags.Where(x => x.TagName == name).FirstOrDefault();
             
        }

        internal void AddTag(string tagName)
        {
            List<rTag> tags = (List<rTag>)GetAllTags();
            if (tags.FindIndex(x=> x.TagName == tagName)<0)
            {
                tags.Add(new rTag() { TagName = tagName });
            }
            var pertags = "";
            //persist
           for (int i=0; i < tags.Count; i++)
            {
                if (i > 0)
                    pertags += ";";

                pertags += tags[i].TagName;
            }
            Settings.KeyWords = pertags;
        }
        internal void DeleteAllObjects()
        {

            Settings.KeyWords = "";

        }

        private Transaction _transaction = null;
        internal Transaction BeginUpdateDocument()
        {
            if (_transaction != null)
                _transaction.Dispose();

            _transaction = _realm.BeginWrite();
            return _transaction;
        }
        internal void EndUpdateDocument()
        {
            _transaction.Commit();
            _transaction.Dispose();
        }
        internal void CancelUpdateDocument()
        {
            if (_transaction != null)
            _transaction.Dispose();
        }
        internal IEnumerable<rDocument> GetAllDocuments()
        {

            var query = _realm.All<rDocument>();//.OrderByDescending(o => o.Created) as RealmResults<rDocument>;

            var coll =   query.ToNotifyCollectionChanged(e =>
            {
                System.Diagnostics.Debug.WriteLine(e);
            }) as IEnumerable<rDocument>;
            return coll;
        }
        internal  dynamic GetDocument(string name)
        {
            var query = _realm.All<rDocument>().Single(e => e.Name == name);
            return query;
        }

        internal void AddDocument(string fileName, DateTime created, string pdfcontent, bool local)
        {
            using (var transaction = _realm.BeginWrite())
            {
                var obj = _realm.CreateObject<rDocument>();
                obj.Created = created;
                obj.ContentAsText = pdfcontent;
                obj.local = true;
                obj.Name = fileName;
                obj.Synced = DateTime.Now;
                transaction.Commit();
            }
        }
        internal  void DeleteAllDocuments()
        {   
                var transaction = _realm.BeginWrite();
                _realm.RemoveAll("rDocument");
                transaction.Commit();
        }
        internal void AddDocument(rDocument doc)
        {
            using (var transaction = _realm.BeginWrite())
            {
                var obj = Realm.GetInstance().CreateObject<rDocument>();
                obj.ContentAsText = doc.ContentAsText;
                obj.Created = doc.Created;
                obj.KeyWords = doc.KeyWords;
                obj.local = doc.local;
                obj.Name = doc.Name;
                obj.Synced = DateTime.Now;

                transaction.Commit();
            }
        }
        


    }
}
