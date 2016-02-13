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
			SignUpNextButton.TouchUpInside +=  (object sender, EventArgs e) => {


				var account = new Account();
				account.FirstName = SignUpFirstName.Text;
				account.LastName = SignUpLastName.Text;
				account.BirthDate = SignUpBirthdate.Text;
				account.Email = SignUpEmail.Text;
				account.Username = SignUpUsername.Text;
				account.Password = SignUpPassword.Text;

				AccountManager.CreateAccount(account);

			};

		}
	}
}
