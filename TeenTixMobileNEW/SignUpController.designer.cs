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
	[Register ("SignUpController")]
	partial class SignUpController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField SignUpBirthdate { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField SignUpEmail { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField SignUpFirstName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField SignUpLastName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SignUpNextButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField SignUpPassword { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField SignUpUsername { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (SignUpBirthdate != null) {
				SignUpBirthdate.Dispose ();
				SignUpBirthdate = null;
			}
			if (SignUpEmail != null) {
				SignUpEmail.Dispose ();
				SignUpEmail = null;
			}
			if (SignUpFirstName != null) {
				SignUpFirstName.Dispose ();
				SignUpFirstName = null;
			}
			if (SignUpLastName != null) {
				SignUpLastName.Dispose ();
				SignUpLastName = null;
			}
			if (SignUpNextButton != null) {
				SignUpNextButton.Dispose ();
				SignUpNextButton = null;
			}
			if (SignUpPassword != null) {
				SignUpPassword.Dispose ();
				SignUpPassword = null;
			}
			if (SignUpUsername != null) {
				SignUpUsername.Dispose ();
				SignUpUsername = null;
			}
		}
	}
}
