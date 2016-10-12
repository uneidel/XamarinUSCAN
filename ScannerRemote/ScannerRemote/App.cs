using ScannerRemote.Helpers;
using ScannerRemote.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ScannerRemote
{
    public class App : Application
    {
        public App()
        {
            InitApp();
            MainPage = new NavigationPage(new Main());
        }

        private void InitApp()
        {
            Settings.ServerAddress = "192.168.178.44";
            string[] tags = new string[] { "Versicherung", "Krankenkasse", "Steuer", "Bank", "Microsoft", "Privat" };
            foreach (var t in tags)
            {
                var rTags = DAL.RealmDAL.Instance;
                rTags.AddTag(t);
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
