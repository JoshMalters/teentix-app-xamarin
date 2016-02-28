using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

using TeenTix.Common;
using TeenTix.Common.Model;

namespace TeenTixMobileNEW
{
	partial class TermsController : UIViewController
	{
		public SignUpAccount NewAccount { get; set; }

		public TermsController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			TermsButton.TouchUpInside += async (object sender, EventArgs e) => {

				NewAccount.AgreedToTOS = true;

				DisableFormAndShowSpinner();

				var result = await AccountManager.CreateAccount(NewAccount);

				if (result.Success) {
					PerformSegue("SegueToVerifyEmail", this);
				} else {
					EnableSignUpFormAndShowError(result.ErrorMessage);
				}
			};
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			if ("SegueToVerifyEmail".Equals (segue.Identifier)) {
				var verifyEmailController = segue.DestinationViewController as VerifyEmailController;
				if (verifyEmailController != null) {
					verifyEmailController.LoginInfo = GetLoginInfo ();
				}
			} else if ("SegueToSignUpOnError".Equals(segue.Identifier)) {
				// TODO: implement this!
			}
		}

		private LoginRequest GetLoginInfo() {
			var info = new LoginRequest ();
			info.Email = NewAccount.Email;
			info.Password = NewAccount.Password;
			return info;
		}

		private void DisableFormAndShowSpinner() {
			// TODO: implement me!
		}

		private void EnableSignUpFormAndShowError(string errorMessage) {
			// TODO: implement form! (maybe use SegueToSignUpOnError segue)
		}
	}

}
