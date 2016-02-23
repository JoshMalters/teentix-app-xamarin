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
					EmailMessage.Text = "Your Email is Valid";
				} else {
					EmailMessage.Text = "Your Email is not Valid";
				}
			};

			SignUpUsername.EditingDidEnd += async (object sender, EventArgs e) => {
				string username = SignUpUsername.Text;
				bool results = await AccountManager.IsUsernameAvailable(username);
				if (results) {
					UsernameMessage.Text = "Your Username is Valid";
				} else {
					UsernameMessage.Text = "Your Username is not Valid";
				}
			};
			
			// TODO: make async! (thomasvandoren, 2016-02-11)
			SignUpNextButton.TouchUpInside += async (object sender, EventArgs e) => {

				// FIXME: The following code is completely untested. It compiles, but that's it. (thomasvandoren, 2016-02-22)
				var account = new SignUpAccount();
				account.Email = SignUpEmail.Text;
				account.ScreenName = SignUpUsername.Text;
				account.Password = SignUpPassword.Text;

				// TODO: really have users set this somewhere! (thomasvandoren, 2016-02-15)
				account.AgreedToTOS = true;

				var result = await AccountManager.CreateAccount(account);

			};

		}
	}
}
