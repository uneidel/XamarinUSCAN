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
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using ScannerRemote.Controls;
using System.Net;
using ScannerRemote.Droid;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace ScannerRemote.Droid
{
    public class CustomWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var customWebView = Element as CustomWebView;
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                if (customWebView.Uri != null)
                    Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", WebUtility.UrlEncode(customWebView.Uri)));

            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var customWebView = Element as CustomWebView;
            if (e.PropertyName == "Uri")
            {
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}",
                    WebUtility.UrlEncode(customWebView.Uri)));
            }
        }

    }
}