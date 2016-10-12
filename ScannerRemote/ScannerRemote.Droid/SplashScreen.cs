using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using System.Threading.Tasks;
using ScannerRemote.Helpers;

using Android.Graphics;
using Android.Content.PM;

namespace ScannerRemote.Droid
{
    [Activity(Theme = "@android:style/Theme.NoTitleBar", MainLauncher = true, Immersive = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreenActivity : Activity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SplashScreen);
            FindViewById<TextView>(Resource.Id.txtAppVersion).Text = $"ScannerRemote Version {PackageManager.GetPackageInfo(PackageName, 0).VersionName}";
            
            var serveraddress = Settings.ServerAddress;
            var intent = new Intent(this, typeof(MainActivity));
            intent.SetFlags(ActivityFlags.NewTask);
            StartActivity(intent);
            Finish();
            

        }

      
    }
    
    /*
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            
            
        }

        protected override void OnResume()
        {
            base.OnResume();

            T
        }
    }
    */
}