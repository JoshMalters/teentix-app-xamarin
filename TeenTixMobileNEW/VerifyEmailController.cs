using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

using TeenTix.Common;
using TeenTix.Common.Model;

namespace TeenTixMobileNEW
{
	partial class VerifyEmailController : UIViewController
	{
		public LoginRequest LoginInfo { get; set; }

		public VerifyEmailController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			LoginButton.TouchUpInside += async (object sender, EventArgs e) => {

				DisableButtonAndShowSpinner();

				var result = await AccountManager.Login (LoginInfo);

				if (result.Success) {
					RestAPI.Session = result.Session;
					PerformSegue("SegueToHowItWorks", this);
				} else {
					EnableButtonAndShowSpinner(result.ErrorMessage);
				}
			};
		}

		private void DisableButtonAndShowSpinner() {
			// TODO: implement me!
		}

		private void EnableButtonAndShowSpinner(string message) {
			// TODO: implement button enable!
			VerifyMessage.Text = message;
		}
	}
}
