using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

using TeenTix.Common;

namespace TeenTixMobileNEW
{
	partial class HomePageController : UIViewController
	{
		public HomePageController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SessionText.Text = RestAPI.Session;
		}
	}
}
