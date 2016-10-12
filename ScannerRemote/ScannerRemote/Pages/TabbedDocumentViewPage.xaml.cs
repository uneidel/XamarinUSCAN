using ScannerRemote.Data;
using ScannerRemote.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ScannerRemote.Pages
{
    public partial class TabbedDocumentViewPage : TabbedPage
    {
        public TabbedDocumentViewPage(DocumentDetailModel viewmodel)
        {
            InitializeComponent();
            BindingContext = viewmodel;
        }
        
    }
}
