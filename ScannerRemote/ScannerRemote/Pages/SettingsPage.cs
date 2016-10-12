using ScannerRemote.Controls;
using ScannerRemote.DAL;
using ScannerRemote.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ScannerRemote.Pages
{

    public class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            BindingContext = new SettingsModel();

            var ServerAddress = new EntryCell{Label = "Server Address:",Placeholder = "Type Address Here" };
            ServerAddress.SetBinding(EntryCell.TextProperty, Constants.SERVERADDRESS, BindingMode.TwoWay);
            
            var ServerPort = new EntryCell{Label = "Server Port:",Placeholder = "Type Port Here" };
            ServerPort.SetBinding(EntryCell.TextProperty, Constants.SERVERPORT, BindingMode.TwoWay);
            
            var Unpaper = new SwitchCell{ Text = "PreProcess:" };
            Unpaper.SetBinding(SwitchCell.OnProperty, Constants.PREPROCESS, BindingMode.TwoWay);
            
            var merge = new SwitchCell{ Text = "Merge:" };
            merge.SetBinding(SwitchCell.OnProperty, Constants.MERGE, BindingMode.TwoWay);
            
            var filternontagged = new SwitchCell{ Text = "Show only NonTagged:" };
            filternontagged.SetBinding(SwitchCell.OnProperty, Constants.FILTERNONTAGGED, BindingMode.TwoWay);
            
            var createPDFfromPic = new SwitchCell{ Text = "Create PDF from Picture:" };
            createPDFfromPic.SetBinding(SwitchCell.OnProperty, Constants.CREATEPDFFROMPIC, BindingMode.TwoWay);

            var resolutionPicker = new Picker();
            foreach (int resolution in Constants.scanResolution)
                resolutionPicker.Items.Add(resolution.ToString());
            resolutionPicker.SelectedIndex = Constants.scanResolution.TakeWhile(x => x != Settings.Resolution).Count();
            var resolutionPickerCell = new PickerCell{ Label = "Select Resolution:", Picker = resolutionPicker };

            var formatPicker = new Picker();
            foreach (string format in Constants.picformats)
            {
                formatPicker.Items.Add(format);
                formatPicker.SelectedIndex = Constants.picformats.TakeWhile(x => x != Settings.Format).Count();
            }
            var formatPickerCell = new PickerCell{ Label = "Select Format:", Picker = formatPicker };

            TableView SettingsTable = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection("Server Settings")
                    {
                        ServerAddress,
                        ServerPort
                    },
                    new TableSection("Scan to PDF")
                    {
                        Unpaper,
                        merge
                    },
                    new TableSection("Documents")
                    {
                        filternontagged
                    },
                    new TableSection("Scan To Picture")
                    {
                        createPDFfromPic,
                        resolutionPickerCell,
                        formatPickerCell
                    }
                }
            };


            Button BtnResetData = new Button{ Text = "Reset Data", BorderRadius = 15 };
            BtnResetData.Clicked += async (s, e) =>
            {
                var action = await DisplayActionSheet("Reset Document Data: Really?", "Cancel", null, "Yes", "No");
                if (action == "Yes")
                {
                    var dal = DAL.RealmDAL.Instance;
                    dal.DeleteAllDocuments();
                    dal.DeleteAllObjects();
                }
            };
            Content = new StackLayout
            {
                Children =
                {
                    SettingsTable,
                    BtnResetData
                }
            };
            
            
        }
    }

}