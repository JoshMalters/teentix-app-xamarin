using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

using TeenTix.Common;
using TeenTix.Common.Model;

namespace TeenTixMobileNEW
{
	partial class PassWebViewController : UIWebView
	{
		public PassWebViewController (IntPtr handle) : base (handle)
		{
		}

		public void ViewDidLoad ()
		{
//			PassWebViewController = new UIWebView (PassWebViewController.Bounds);
//			PassWebViewController.AddSubview(PassWebViewController);
//
//			var url = "http://www.teentix.org/sign-up/application"; // NOTE: https secure request
//			PassWebViewController.LoadRequest(new NSUrlRequest(new NSUrl(url)));
//
//			PassWebViewController.ScalesPageToFit = true;
		}
	}
}
