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

				// TODO: disable form and show spinner, while account create happens...
				var result = await AccountManager.CreateAccount(NewAccount);

				if (result.Success) {
					ContinueToHowItWorks();
				} else {
					EnableSignUpFormAndShowError(result.ErrorMessage);
				}
			};
		}

		private void DisableFormAndShowSpinner() {
			// TODO: implement me!
		}

		private void EnableSignUpFormAndShowError(string errorMessage) {
			// TODO: implement me!
		}

		private void ContinueToHowItWorks() {
			// TODO: implement me!
		}
	}

}
