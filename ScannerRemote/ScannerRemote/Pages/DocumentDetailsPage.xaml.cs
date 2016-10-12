using ScannerRemote.DAL;
using ScannerRemote.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ScannerRemote.Pages
{
    public partial class DocumentDetailsPage : ContentPage
    {
        public DocumentDetailsPage()
        {
            InitializeComponent();
            //ic_add_white_24dp.png
            tbitem = new ToolbarItem();
            tbitem.Icon = "ic_add_white_24dp.png";
            this.ToolbarItems.Add(tbitem);
            
        }
        ToolbarItem tbitem = null;
        
        protected async override void OnAppearing()
        {
            var viewmodel = (DocumentDetailModel)BindingContext;
            Taglsv.SelectedItem = RealmDAL.Instance.GetTag(viewmodel.Entry.KeyWords);
            Taglsv.ItemSelected += OnItemSelected;
            
            tbitem.Clicked += async (x, y) =>
            {
                await Navigation.PushAsync(new TagManagePage(new TagManageModel(viewmodel.Tags)));

            };
        }
       
        
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var keyword = (rTag)e.SelectedItem;
            var viewmodel = (DocumentDetailModel)BindingContext;
            using (var trans = RealmDAL.Instance.BeginUpdateDocument())
            { 
                viewmodel.Entry.KeyWords = keyword.TagName;
                viewmodel.Entry.local = false;
                trans.Commit();
            }
        }

       

        void onViewCellTapped(object sender, EventArgs e)
        {
            ViewCell c = (ViewCell)sender;
            c.View.BackgroundColor = Color.FromHex("FFC240");
            
        }
    }
}
