// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TeenTixMobileNEW
{
	[Register ("VerifyEmailController")]
	partial class VerifyEmailController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton LoginButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel VerifyMessage { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (LoginButton != null) {
				LoginButton.Dispose ();
				LoginButton = null;
			}
			if (VerifyMessage != null) {
				VerifyMessage.Dispose ();
				VerifyMessage = null;
			}
		}
	}
}
