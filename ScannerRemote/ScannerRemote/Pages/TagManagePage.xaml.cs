using ScannerRemote.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ScannerRemote.Pages
{
    public partial class TagManagePage : ContentPage
    {
        public TagManagePage(TagManageModel viewmodel)
        {
            BindingContext = viewmodel;
            InitializeComponent();
        }
        protected override void OnDisappearing()
        {
            var viewModel = (TagManageModel)BindingContext;
            if (viewModel.AddEntryCommand.CanExecute(null))
                viewModel.AddEntryCommand.Execute(null);
        }
    }
}
