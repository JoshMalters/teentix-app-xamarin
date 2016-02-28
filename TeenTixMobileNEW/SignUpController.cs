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

			SignUpNextButton.TouchUpInside += async (object sender, EventArgs e) => {

				var newAccount = new SignUpAccount();
				newAccount.Email = SignUpEmail.Text;
				newAccount.ScreenName = SignUpUsername.Text;
				newAccount.Password = SignUpPassword.Text;

				var validResult = await AccountManager.ValidateAccount(newAccount);
				if (!validResult.Valid) {
					// TODO: Consider using one generic message box for all messages... (thomasvandoren, 2016-02-27)
					EmailMessage.Text = validResult.Message;
					UsernameMessage.Text = "";
				} else {
					// go to TermsController, and pass account along.

					var termsController = this.Storyboard.InstantiateViewController("TermsController") as TermsController;

					if (termsController != null) {
						termsController.NewAccount = newAccount;
						this.NavigationController.PushViewController(termsController, true);
					} else {
						Console.WriteLine("TEENTIX: Failed to instantiate TermsController!");
					}
				}
			};
		}

		public override bool ShouldPerformSegue (string segueIdentifier, NSObject sender)
		{


			return base.ShouldPerformSegue (segueIdentifier, sender);
		}

//
//		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
//		{
//			base.PrepareForSegue (segue, sender);
//
//			Console.WriteLine ("TEENTIX: Inside PrepareForSeque");
//			var termsController = segue.DestinationViewController as TermsController;
//
//			Console.WriteLine ("termsController = {0}", termsController);
//			if (termsController != null) {
//				termsController.NewAccount = new SignUpAccount();
//				termsController.NewAccount.Email = SignUpEmail.Text;
//				termsController.NewAccount.ScreenName = SignUpUsername.Text;
//				termsController.NewAccount.Password = SignUpPassword.Text;;
//			} else {
//				throw new Exception ("could not load TremsController!");
//			}
//		}
	}
}
