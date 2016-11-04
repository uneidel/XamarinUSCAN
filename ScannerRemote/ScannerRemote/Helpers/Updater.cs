using Plugin.Connectivity;
using ScannerRemote.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScannerRemote.Helpers
{
    public class Updater
    {
        private  ProgressBar progressbar = null;
        private Label lbl = null;
        private string serveraddress = null;

        #region Ctors
        public Updater()
        {

        }
        public Updater(string serveraddress)
        {

        }
        public Updater(string serveraddress, ProgressBar pgbar, View vw)
        {
            this.progressbar = pgbar;
            this.lbl =  vw as Label;
            this.serveraddress = serveraddress;
        }

        #endregion


        private async Task<bool> CheckConnectivity()
        {

            //TODO 
            bool bret = await CrossConnectivity.Current.IsReachable(serveraddress, 1000);
            return bret;
        }
        public  async Task UpdateDocuments()
        {
           
          
            try
            {
                UpdateProgressBar(0.1);
                UpdateLabel("Checking for Updates");
                

                var rest = new apihelper();
                var tmp =  await rest.GetFiles();
                if (tmp == null)
                {
                    // Loading files went wrong
                    UpdateProgressBar(1.0);
                    UpdateLabel("An error occured");
                    return;
                }
              
                var docsindb = DAL.RealmDAL.Instance.GetAllDocuments();
                var count = 0;
                foreach (var t in tmp)
                {
                    count++;
                    if (docsindb.Where(x => x.Name.ToLower() == t.FileName.ToLower()).FirstOrDefault() == null)
                    {
                        UpdateLabel(String.Format("Downloading {0}/{1}", count, tmp.Count));
                        var content = await rest.DownloadFile(t.FileName);
                        await StorageHelper.WriteFileToStorage(t.FileName, content);
                        var txtcontent = await rest.GetPDFContent(t.FileName);
                        RealmDAL.Instance.AddDocument(t.FileName, t.CreationTime,txtcontent, true);
                        IncrementProgress((0.8 / tmp.Count));
                    }
                }

                UpdateLabel("Syncing KeyWords");
                var filestoUpdate = docsindb.Where(x => !String.IsNullOrEmpty(x.KeyWords) && x.local == false).ToArray();
                foreach (var doc in filestoUpdate)
                {
                    await rest.UpdateKeyWord(doc.Name, doc.KeyWords);
                    using (var trans = RealmDAL.Instance.BeginUpdateDocument())
                    {
                        doc.pdfupdated = true;
                        trans.Commit();
                    }
                }
              
                UpdateProgressBar(1.0);
                UpdateLabel("Finish");
            }
            catch (Exception ex)
            {
                var foo = ex;
                //Handle Exception
            }
        }

        private void UpdateLabel(string newvalue)
        {
            if (lbl != null)
                lbl.Text = newvalue;
        }
        private  void UpdateProgressBar(double newvalue)
        {
            if (this.progressbar != null)
                progressbar.Progress = newvalue;
        }
        private  void IncrementProgress(double increment)
        {
            if (this.progressbar != null)
            this.progressbar.ProgressTo(progressbar.Progress + increment, (uint)(progressbar.Progress + increment), Easing.Linear);
        }
    }
}
