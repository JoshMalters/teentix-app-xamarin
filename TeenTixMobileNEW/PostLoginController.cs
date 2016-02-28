using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

using TeenTix.Common;

namespace TeenTixMobileNEW
{
	partial class PostLoginController : UIViewController
	{
		public PostLoginController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			LoginSession.Text = RestAPI.Session;
		}
	}
}
