using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

using TeenTix.Common;
using TeenTix.Common.Model;

namespace TeenTixMobileNEW
{
	partial class SignUpController : UIViewController
	{
		public SignUpController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SignUpEmail.EditingDidEnd += async (object sender, EventArgs e) => {
				string email = SignUpEmail.Text;
				bool results = await AccountManager.IsEmailAvailable (email);

				Console.WriteLine(email + results);
				if (results) {
					SignUpMessage.Text = "Your Email is Valid";
				} else {
					SignUpMessage.Text = "Your Email is not Valid";
				}
			};

			SignUpUsername.EditingDidEnd += async (object sender, EventArgs e) => {
				string username = SignUpUsername.Text;
				bool results = await AccountManager.IsUsernameAvailable(username);
				if (results) {
					SignUpMessage.Text = "Your Username is Valid";
				} else {
					SignUpMessage.Text = "Your Username is not Valid";
				}
			};
		}

		public override bool ShouldPerformSegue (string segueIdentifier, NSObject sender)
		{
			if ("SegueToTerms".Equals (segueIdentifier)) {
				var accountIsValid = AccountManager.ValidateAccount (AccountFromForm());
				if (!accountIsValid.Valid) {
					SignUpMessage.Text = accountIsValid.Message;
				}
				return accountIsValid.Valid;
			}
			return base.ShouldPerformSegue (segueIdentifier, sender);
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			var termsController = segue.DestinationViewController as TermsController;

			if (termsController != null) {
				termsController.NewAccount = AccountFromForm ();
			} else {
				throw new Exception ("could not load TremsController!");
			}
		}

		private SignUpAccount AccountFromForm() {
			var result = new SignUpAccount ();
			result.Email = SignUpEmail.Text;
			result.ScreenName = SignUpUsername.Text;
			result.Password = SignUpPassword.Text;
			return result;
		}
	}
}
