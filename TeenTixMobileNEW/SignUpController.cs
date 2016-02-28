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

		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			Console.WriteLine ("TEENTIX: Inside PrepareForSeque");
			var termsController = segue.DestinationViewController as TermsController;

			Console.WriteLine ("termsController = {0}", termsController);
			if (termsController != null) {
				termsController.NewAccount = new SignUpAccount();
				termsController.NewAccount.Email = SignUpEmail.Text;
				termsController.NewAccount.ScreenName = SignUpUsername.Text;
				termsController.NewAccount.Password = SignUpPassword.Text;;
			} else {
				throw new Exception ("could not load TremsController!");
			}
		}
	}
}
