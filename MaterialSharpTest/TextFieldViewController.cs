using Foundation;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using UIKit;
using MaterialSharp;

namespace MaterialSharpTest
{
	[DesignTimeVisible (true)]
	partial class TextFieldViewController : UIViewController
	{
		public TextFieldViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// No border, no shadow, floatPlaceHolderDisabled
			textField1.Layer.BorderColor = UIColor.Clear.CGColor;
			textField1.Placeholder = "Placeholder";
			textField1.TintColor = UIColor.Gray;

			// No border, shadow, floatPlaceHolderDisabled
			textField2.Layer.BorderColor = UIColor.Clear.CGColor;
			textField2.Placeholder = "Repo name";
			textField2.BackgroundColor = new UIColor (0.878f, 0.878f, 0.878f, 1);
			textField2.TintColor = UIColor.Gray;

			// Border, no shadow, floatPlaceHolderDisabled
			textField3.Layer.BorderColor = MaterialColor.Grey.CGColor;
			textField3.CircleLayerColor = MaterialColor.Amber;
			textField3.TintColor = MaterialColor.DeepOrange;
			textField3.RippleLocation = RippleLocation.Left;

			// No border, no shadow, floatingPlaceholderEnabled
			textField4.Layer.BorderColor = UIColor.Clear.CGColor;
			textField4.FloatingPlaceholder = true;
			textField4.Placeholder = "Github";
			textField4.TintColor = MaterialColor.Blue;
			textField4.RippleLocation = RippleLocation.Right;
			textField4.CornerRadius = 0;
			textField4.BottomBorder = true;

			// No border, shadow, floatingPlaceholderEnabled
			textField5.Layer.BorderColor = UIColor.Clear.CGColor;
			textField5.FloatingPlaceholder = true;
			textField5.Placeholder = "Email account";
			textField5.CircleLayerColor = MaterialColor.LightBlue;
			textField5.TintColor = MaterialColor.Blue;
			textField5.BackgroundColor = new UIColor (0.878f, 0.878f, 0.878f, 1);

			// Border, floatingPlaceholderEnabled
			textField6.FloatingPlaceholder = true;
			textField6.CornerRadius = 1;
			textField6.Placeholder = "Description";
			textField6.Layer.BorderColor = MaterialColor.Green.CGColor;
			textField6.CircleLayerColor = MaterialColor.LightGreen;
			textField6.TintColor = MaterialColor.LightGreen;
		}
	}
}
