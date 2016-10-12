using Realms;
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
    public class Main : ContentPage
    {
        public Main()
        {
            ProgressBar pgbar = new ProgressBar();
            pgbar.IsVisible = false;
            Label l = new Label();

            Title = "ScannerRemote v0.9";
            NavigationPage.SetHasNavigationBar(this, true);
            Button BtnSettings = new Button
            {
                Text = "Settings",BorderRadius = 15
            };
            BtnSettings.Clicked += async (s, e) =>
            {
                await Navigation.PushAsync(new SettingsPage());
            };
            Button BtnDocuments = new Button
            {
                Text = "Documents",
                BorderRadius = 15

            };

            BtnDocuments.Clicked += async (s, e) =>
            {
                await Navigation.PushAsync(new DocumentListPage());
            };
            Button BtnScanToPDF = new Button
            {
                Text = "Scan To PDF"
            };
            BtnScanToPDF.Clicked += async (s, e) =>
            {
                var rest = new apihelper();
                bool sucess = await rest.scanToPDF(true, false);
                UpdateLabel(l, "Scan to PDF sucessfull.");

            };
            Button BtnScanAndMergeToPDF = new Button
            {
                Text = "Scan and Merge"
            };
            BtnScanAndMergeToPDF.Clicked += async (s, e) =>
            {
                var rest = new apihelper();
                bool sucess = await rest.scanToPDF(true, false);
                UpdateLabel(l, "Scan and Merge sucessfull.");
            };
            Button BtnScanToImg = new Button
            {
                Text = "Scan To\n Image"
            };
            BtnScanToImg.Clicked += async (s, e) =>
             {
                 var rest = new apihelper();
                 bool sucess = await rest.scanToPIC();
                 UpdateLabel(l, "Scan Image sucessfull.");
             };

            Button BtnUpdate = new Button
            {
                Text = "Update"
            };
            BtnUpdate.Clicked += async (s, e) =>
            {
                pgbar.IsVisible = true;
                Updater updater = new Helpers.Updater(Settings.ServerAddress, pgbar, l);
                await updater.UpdateDocuments();
            };

            StackLayout updaterinfo = new StackLayout();
            updaterinfo.VerticalOptions = Xamarin.Forms.LayoutOptions.EndAndExpand;
            updaterinfo.Children.Add(pgbar);
            updaterinfo.Children.Add(l);


            

            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            grid.Children.Add(BtnScanToPDF, 0, 0);
            grid.Children.Add(BtnScanAndMergeToPDF, 0, 1);
            grid.Children.Add(BtnScanToImg, 1, 0);
            grid.Children.Add(BtnDocuments, 1, 1);
            grid.Children.Add(BtnUpdate, 2, 0);


            Content = new StackLayout
            {
                Children = {
                    grid,
                    updaterinfo
                }
            };
            
            ToolbarItems.Add(new ToolbarItem
            {
                Icon = "ic_settings_white_24dp.png",
                Order = ToolbarItemOrder.Primary,
                Command = new Command(() => Navigation.PushAsync(new SettingsPage()))
            });
        }

        private void UpdateLabel(Label l,string newvalue)
        {
            if (l != null)
                l.Text = newvalue;
        }
        protected async override void OnAppearing()
        {   
            
        }
    }

}
