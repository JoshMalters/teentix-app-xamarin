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
	[Register ("HomePageController")]
	partial class HomePageController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView SessionText { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (SessionText != null) {
				SessionText.Dispose ();
				SessionText = null;
			}
		}
	}
}
