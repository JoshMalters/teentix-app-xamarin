using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

using TeenTix.Common;
using TeenTix.Common.Model;

namespace TeenTixMobileNEW
{
	partial class LoginController : UIViewController
	{
		private bool done = false;

		public LoginController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			LoginButton.TouchUpInside += async (object sender, EventArgs e) => {
				var valid = AccountManager.ValidateLogin(LoginFromForm());
				if (!valid.Valid) {
					LoginMessage.Text = valid.Message;
					return;
				}

				DisableFormAndShowSpinner();

				var result = await AccountManager.Login (LoginFromForm());

				if (result.Success) {
					RestAPI.Session = result.Session;
//					this.PerformSegue("SegueToHome", this);
					PerformSegue("SegueToPostLoginManual", this);
					done = true;
				} else {
					EnableFormAndShowError(result.ErrorMessage);
				}
			};
		}

		private void DisableFormAndShowSpinner() {
			// TODO: implement me!
		}

		private void EnableFormAndShowError(string errorMessage) {
			// TODO: implement for enable! (thomasvandoren, 2016-02-27)
			LoginMessage.Text = errorMessage;
		}

		private LoginRequest LoginFromForm() {
			var result = new LoginRequest ();
			result.Email = LoginEmail.Text;
			result.Password = LoginPassword.Text;
			return result;
		}
	}
}
