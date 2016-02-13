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
	[Register ("LoginController")]
	partial class LoginController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel loginEmailMessage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel loginUsernameMessage { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (loginEmailMessage != null) {
				loginEmailMessage.Dispose ();
				loginEmailMessage = null;
			}
			if (loginUsernameMessage != null) {
				loginUsernameMessage.Dispose ();
				loginUsernameMessage = null;
			}
		}
	}
}
