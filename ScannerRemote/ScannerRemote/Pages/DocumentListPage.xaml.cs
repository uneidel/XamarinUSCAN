using Newtonsoft.Json;
using ScannerRemote.DAL;
using ScannerRemote.Data;
using ScannerRemote.Helpers;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ScannerRemote.Pages
{
    public partial class DocumentListPage : ContentPage
    {
        //public ObservableCollection<Helpers.DocumentListViewModel> pdfs { get; set; }
        public  DocumentListPage()
        {
            InitializeComponent();
            BindingContext = new DocumentListModel { Navigation = Navigation };
            ToolbarItem tbitem = new ToolbarItem();
            tbitem.Icon = "ic_filter_list_white_24dp.png";
            this.ToolbarItems.Add(tbitem);
            tbitem.Clicked += async (x, y) =>
            {
                
                var entries =(IEnumerable<rDocument>)lstView.ItemsSource;
                lstView.ItemsSource = entries.Where(itm => itm.local == false).ToArray();
                
            };
            
        }





        private void LstView_ItemTapped(object sender, ItemTappedEventArgs e)
        {   
           var docItem=  e.Item as rDocument;
            (BindingContext as DocumentListModel).EditEntry(docItem);
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var docItem = e.SelectedItem as rDocument;
                (BindingContext as DocumentListModel).EditEntry(docItem);
                
            }
            catch(Exception ex)
            {
                var foo = ex;
            }
        }
    }
}
