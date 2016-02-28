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
		public LoginController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			LoginButton.TouchUpInside += async (object sender, EventArgs e) => {

				DisableFormAndShowSpinner();

				var result = await AccountManager.Login (LoginFromForm());

				if (result.Success) {
					ContinueToHome();
				} else {
					EnableFormAndShowError(result.ErrorMessage);
				}
			};
		}

		private void DisableFormAndShowSpinner() {
			// TODO: implement me!
		}

		private void EnableFormAndShowError(string errorMessage) {
			// TODO: implement me!
		}

		private void ContinueToHome() {
			// TODO: implement me!
		}

		private LoginRequest LoginFromForm() {
			var result = new LoginRequest ();
			result.Email = LoginEmail.Text;
			result.Password = LoginPassword.Text;
			return result;
		}
	}
}
