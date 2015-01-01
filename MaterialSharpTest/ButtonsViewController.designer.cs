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

namespace MaterialSharpTest
{
	[Register ("ButtonsViewController")]
	partial class ButtonsViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MaterialSharp.MaterialButton flatbkg { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MaterialSharp.MaterialButton flatbutton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MaterialSharp.MaterialButton floatbutton1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MaterialSharp.MaterialButton floatbutton2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MaterialSharp.MaterialButton imagebutton1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MaterialSharp.MaterialButton imagebutton2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MaterialSharp.MaterialButton raisedButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (flatbkg != null) {
				flatbkg.Dispose ();
				flatbkg = null;
			}
			if (flatbutton != null) {
				flatbutton.Dispose ();
				flatbutton = null;
			}
			if (floatbutton1 != null) {
				floatbutton1.Dispose ();
				floatbutton1 = null;
			}
			if (floatbutton2 != null) {
				floatbutton2.Dispose ();
				floatbutton2 = null;
			}
			if (imagebutton1 != null) {
				imagebutton1.Dispose ();
				imagebutton1 = null;
			}
			if (imagebutton2 != null) {
				imagebutton2.Dispose ();
				imagebutton2 = null;
			}
			if (raisedButton != null) {
				raisedButton.Dispose ();
				raisedButton = null;
			}
		}
	}
}
