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

			SignUpNextButton.TouchUpInside += (object sender, EventArgs e) => {


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
